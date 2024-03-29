using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.CodeGenerator.Views;
using Infrastructure.CodeGenerator.Logic;
using Infrastructure.UserInterface;
using Infrastructure.CodeGenerator.Logic.TypeConversions;

namespace Infrastructure.CodeGenerator.Presenters
{
	class TypeDetailsPresenter : CodeGeneratorPresenter<TypeDetailsView>
	{
		Infrastructure.CodeGenerator.Logic.Type type;

		public event EventHandler TypeModified;

		public TypeDetailsPresenter(Infrastructure.CodeGenerator.Logic.Type type)
			: base()
		{
			this.type = type;
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.Type = type);

			return base.Initialize();
		}

		protected override bool InitializeEvents()
		{
			UpdateView(view => view.SetTypeConversionRequest += new RequestHandler<TypeConversion>(t => type.TypeConversion = t));
			UpdateView(view => view.SetProblemResolved += new RequestHandler<bool>(r => type.ProblemIsResolved = r));
			UpdateView(view => view.UserModified += new RequestHandler(() => type.UserModified = true));
			UpdateView(view => view.FunctionChanged += new RequestHandler(() => { if (TypeModified != null) TypeModified(this, EventArgs.Empty); }));

			return base.InitializeEvents();
		}
	}
}
