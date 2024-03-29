using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.CodeGenerator.Views;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.CodeGenerator.Logic;
using Infrastructure.UserInterface;

namespace Infrastructure.CodeGenerator.Presenters
{
	class FunctionDetailsPresenter : CodeGeneratorPresenter<FunctionDetailsView>
	{
		public Function Function { get; private set; }

		public event EventHandler FunctionModified;

		private string name;

		public FunctionDetailsPresenter(Function function)
			: base()
		{
			Function = function;
			name = "FunctionDetails-" + Function.Name;
		}

		public override string Name
		{
			get { return name; }
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.Function = Function);
			UpdateView(view => view.EnableOldFunctionElements = Function.OldFunction != null);

			var presenter = new TypeDetailsPresenter(Function.ReturnType);
			presenter.TypeModified += new EventHandler((o, e) => OnFunctionModified());
			AddChildPresenter(presenter, (view, childView) => view.AddReturnTypeView(Function.ReturnType, childView), true);

			Function.Parameters.Foreach(p =>
			{
				var paramPresenter = new ParameterDetailsPresenter(p);
				paramPresenter.ParameterModified += new EventHandler((o, e) => OnFunctionModified());
				AddChildPresenter(paramPresenter, (view, childView) => view.AddParameterView(p, childView), true);
			});

			return base.Initialize();
		}

		private void OnFunctionModified()
		{
			UpdateView(view => view.Function = Function);
			if (FunctionModified != null)
				FunctionModified(this, EventArgs.Empty);
		}

		protected override bool InitializeEvents()
		{
			UpdateView(view => view.SetUpdateProblemIsResolved += new RequestHandler(() =>
			{
				Function.OldFunction = null;
				view.EnableOldFunctionElements = false;
				OnFunctionModified();
			}));

			UpdateView(view => view.ShowOldFunctionDetails += new RequestHandler(() => Shell.RegisterPresenter(new FunctionDetailsPresenter(Function.OldFunction))));

			return base.InitializeEvents();
		}
	}
}
