using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms;
using System.IO.IsolatedStorage;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using System.Xml.Linq;
using System.Xml;
using Infrastructure.UserInterface;

namespace Infrastructure.UserInterface.WinForms
{
	public static class ShellLayoutPersister
	{
		private const string fileName = "DockLayout.xml";

		public static void PersistLayout(DockPanel dockPanel)
		{
			using (var isolatedStorageFile = IsolatedStorageFile.GetUserStoreForAssembly())
			{
				IsolatedStorageFileStream isolatedStorageFileStream = null;
				try
				{
					isolatedStorageFileStream = new IsolatedStorageFileStream(fileName, FileMode.Create, isolatedStorageFile);
					dockPanel.SaveAsXml(isolatedStorageFileStream, Encoding.UTF8);
				}
				finally
				{
					if (isolatedStorageFileStream != null)
						isolatedStorageFileStream.Close();
				}
			}
		}

		public static void LoadLayout(DockPanel dockPanel, DeserializeDockContent viewDeserializer)
		{
			using (var isolatedStorageFile = IsolatedStorageFile.GetUserStoreForAssembly())
			{
				string[] fileNames = isolatedStorageFile.GetFileNames(fileName);
				if (fileNames.Length != 1)
					throw new InvalidOperationException("No UI layout found in isolated storage. Using default layout.");
				else
				{
					IsolatedStorageFileStream isolatedStorageFileStream = null;
					try
					{
						isolatedStorageFileStream = new IsolatedStorageFileStream(fileNames[0], FileMode.Open, isolatedStorageFile);
						dockPanel.LoadFromXml(isolatedStorageFileStream, viewDeserializer);
					}
					finally
					{
						if (isolatedStorageFileStream != null)
							isolatedStorageFileStream.Close();
					}
				}
			}
		}
	}
}
