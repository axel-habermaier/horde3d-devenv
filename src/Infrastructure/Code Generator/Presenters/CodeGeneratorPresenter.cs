using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.UserInterface;

namespace Infrastructure.CodeGenerator.Presenters
{
	class CodeGeneratorPresenter<TView> : Presenter<TView, CodeGeneratorShell>
		where TView : class, IView, new()
	{
		public CodeGeneratorPresenter() 
			: base()
		{

		}
	}
}
