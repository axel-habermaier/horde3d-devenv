#define WIN32_LEAN_AND_MEAN

#include "CursorSuspendStrategy.h"
#include <Windows.h>
#include "detours.h"

using namespace Server::NativeInterop;

/* Global state */
// ShowCursor function pointer.
typedef int (WINAPI *ptrShowCursor)(__in BOOL);
ptrShowCursor g_pShowCursor;

// ClipCursor function pointer.
typedef BOOL (WINAPI *ptrClipCursor)(__in_opt CONST RECT*);
ptrClipCursor g_pClipCursor;

// SetCursorPos function pointer.
typedef BOOL (WINAPI *ptrSetCursorPos)(__in int, __in int);
ptrSetCursorPos g_pSetCursorPos;

// Indicates whether the application wants the cursor to be visible.
BOOL g_cursorIsVisible = true;

// The clip rectangle specified by the application.
LPRECT g_cursorClipArea = 0;

// The current cursor position when the application was suspended.
POINT g_currentCursorPos;

// Indicates whether the application is currently suspended.
bool g_isSuspended = false;

// This is the function that is actually called when the application calls ShowCursor.
int WINAPI ShowCursorDetour(__in BOOL show)
{
	if (g_isSuspended)
		return 0;

	g_cursorIsVisible = show;
	return g_pShowCursor(show);
}

// This is the function that is actually called when the application calls ClipCursor.
BOOL WINAPI ClipCursorDetour(__in_opt CONST RECT* lpRect)
{
	if (g_isSuspended)
		return TRUE;

	delete g_cursorClipArea;
	g_cursorClipArea = 0;
	if (lpRect != 0)
	{
		g_cursorClipArea = new RECT();
		g_cursorClipArea->bottom = lpRect->bottom;
		g_cursorClipArea->top = lpRect->top;
		g_cursorClipArea->left = lpRect->left;
		g_cursorClipArea->right = lpRect->right;
	}
	return g_pClipCursor(lpRect);
}

// This is the function that is actually called when the application calls SetCursorPos.
BOOL WINAPI SetCursorPosDetour(__in int x, __in int y)
{
	if (g_isSuspended)
		return FALSE;

	g_currentCursorPos.x = x;
	g_currentCursorPos.y = y;
	return g_pSetCursorPos(x, y);
}

void CursorSuspendStrategy::Suspend()
{
	g_isSuspended = true;
	g_pShowCursor(TRUE);
	g_pClipCursor(0);
	::GetCursorPos(&g_currentCursorPos);
}

void CursorSuspendStrategy::Resume()
{
	g_isSuspended = false;
	g_pClipCursor(g_cursorClipArea);
	g_pSetCursorPos(g_currentCursorPos.x, g_currentCursorPos.y);
	g_pShowCursor(g_cursorIsVisible);
}

CursorSuspendStrategy::CursorSuspendStrategy() 
{
	HINSTANCE user32Dll = LoadLibrary("user32.dll");

	g_pShowCursor = (ptrShowCursor)GetProcAddress(user32Dll, "ShowCursor");
	g_pClipCursor = (ptrClipCursor)GetProcAddress(user32Dll, "ClipCursor");
	g_pSetCursorPos = (ptrSetCursorPos)GetProcAddress(user32Dll, "SetCursorPos");

	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());
	DetourAttach(&(PVOID&)g_pClipCursor, ClipCursorDetour);
	DetourAttach(&(PVOID&)g_pShowCursor, ShowCursorDetour);
	DetourAttach(&(PVOID&)g_pSetCursorPos, SetCursorPosDetour);
	DetourTransactionCommit();
	attached = true;
}

CursorSuspendStrategy::~CursorSuspendStrategy()
{
	CleanUp();
}

CursorSuspendStrategy::!CursorSuspendStrategy()
{
	CleanUp();
}

void CursorSuspendStrategy::CleanUp()
{
	if (!attached)
		return;

	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());
	DetourDetach(&(PVOID&)g_pClipCursor, ClipCursorDetour);
	DetourDetach(&(PVOID&)g_pShowCursor, ShowCursorDetour);
	DetourDetach(&(PVOID&)g_pSetCursorPos, SetCursorPosDetour);
	DetourTransactionCommit();

	g_pShowCursor(TRUE);
	g_pClipCursor(NULL);
	delete g_cursorClipArea;
	g_cursorClipArea = 0;
}