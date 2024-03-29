#define WIN32_LEAN_AND_MEAN

#include <Windows.h>
#include "WndProcSuspendStrategy.h"
#include <vcclr.h>
#include <map>

using namespace Server::NativeInterop;

// hWnd to WndProc map
std::map<HWND, LONG_PTR> g_hWndToWndProcMap;

// Keyboard and mouse hooks.
HHOOK g_hookKeyboard, g_hookMouse;

// Indicates whether the application should not receive any input.
bool g_forwardInput = true;

// Global variable that holds the WndProcSuspendStrategy instance.
gcroot<WndProcSuspendStrategy^> g_wndProcStrategy;

LRESULT CALLBACK NoInputWndProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	/*if ((uMsg >= WM_KEYFIRST && uMsg <= UNICODE_NOCHAR) || (uMsg >= WM_NCMOUSEMOVE && uMsg <= WM_NCXBUTTONDBLCLK)
		|| (uMsg >= WM_MOUSEFIRST && uMsg <= WM_MOUSELAST))
		return 0;
	else*/

	if (uMsg == WM_CLOSE || uMsg == WM_DESTROY)
		Environment::Exit(3);

	return DefWindowProc(hwnd, uMsg, wParam, lParam);
}

LRESULT CALLBACK KeyboardProc(int code, WPARAM wParam, LPARAM lParam)
{
	switch (wParam)
	{
	case VK_F8:
		g_wndProcStrategy->ProfilingRequested(g_wndProcStrategy, EventArgs::Empty);
		break;
	case VK_F7:
		g_wndProcStrategy->SuspendRequested(g_wndProcStrategy, EventArgs::Empty);
		break;
	case VK_F5:
		g_wndProcStrategy->ResumeRequested(g_wndProcStrategy, EventArgs::Empty);
		break;
	case VK_ESCAPE:
		Environment::Exit(0);
		break;
	}

	if (code < 0)
		return CallNextHookEx(g_hookKeyboard, code, wParam, lParam);
	/*else if (g_forwardInput)
		return 0;
	else*/
		return 0;
}

BOOL CALLBACK EnumThreadWndProc(HWND hwnd, LPARAM lParam)
{
	//SetFocus(hwnd);
	if (g_forwardInput)
	{
		std::map<HWND, LONG_PTR>::iterator it = g_hWndToWndProcMap.find(hwnd);
		if (it != g_hWndToWndProcMap.end())
		{
			SetWindowLongPtr(hwnd, GWLP_WNDPROC, it->second);
			/*ShowWindow(hwnd, SW_RESTORE);*/
		}
	}
	else
	{
		std::map<HWND, LONG_PTR>::iterator it = g_hWndToWndProcMap.find(hwnd);
		if (it == g_hWndToWndProcMap.end())
		{
			LONG_PTR ptr = GetWindowLongPtr(hwnd, GWLP_WNDPROC);
			g_hWndToWndProcMap.insert(std::pair<HWND, LONG_PTR>(hwnd, ptr));
			SetWindowLongPtr(hwnd, GWLP_WNDPROC, (LONG_PTR)(&NoInputWndProc));
			ShowWindow(hwnd, SW_MINIMIZE);
			ShowWindow(hwnd, SW_RESTORE);
		}
	}
	return FALSE;
}

LRESULT CALLBACK MouseProc(int code, WPARAM wParam, LPARAM lParam)
{
	/*switch (wParam)
	{
	case WM_LBUTTONDOWN:
		if (!g_forwardInput)
		{
			EnumThreadWindows(GetCurrentThreadId(), EnumThreadWndProc, 0);
		}
		break;
	}

	if (code < 0)
		return CallNextHookEx(g_hookMouse, code, wParam, lParam);
	else if (g_forwardInput)
		return 0;
	else*/
		return 0;
}

void WndProcSuspendStrategy::Suspend()
{
	g_hWndToWndProcMap.clear();
	g_forwardInput = false;
	EnumThreadWindows(GetCurrentThreadId(), EnumThreadWndProc, 0);
}

void WndProcSuspendStrategy::Resume()
{
	g_forwardInput = true;
	EnumThreadWindows(GetCurrentThreadId(), EnumThreadWndProc, 0);
}

WndProcSuspendStrategy::WndProcSuspendStrategy()
{
	g_wndProcStrategy = this;
	g_hookKeyboard = SetWindowsHookEx(WH_KEYBOARD, KeyboardProc, 0, GetCurrentThreadId());
	//g_hookMouse = SetWindowsHookEx(WH_MOUSE, MouseProc, 0, GetCurrentThreadId());
}

WndProcSuspendStrategy::~WndProcSuspendStrategy()
{
	CleanUp();
}

WndProcSuspendStrategy::!WndProcSuspendStrategy()
{
	CleanUp();
}

void WndProcSuspendStrategy::CleanUp()
{
	if (g_hookKeyboard != 0)
		UnhookWindowsHookEx(g_hookKeyboard);
	//if (g_hookMouse != 0)
		//UnhookWindowsHookEx(g_hookMouse);
	g_hookKeyboard = 0;
	g_hookMouse = 0;
}