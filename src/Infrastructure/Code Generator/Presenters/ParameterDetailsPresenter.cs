using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.CodeGenerator.Views;
using Infrastructure.CodeGenerator.Logic;

namespace Infrastructure.CodeGenerator.Presenters
{
	class ParameterDetailsPresenter : CodeGeneratorPresenter<ParameterDetailsView>
	{
		Parameter parameter;

		public event EventHandler ParameterModified;

		public ParameterDetailsPresenter(Parameter parameter)
			: base()
		{
			this.parameter = parameter;
		}

		public override string Name
		{
			get { return base.Name + parameter.Name; }
		}

		protected override bool Initialize()
		{
			var presenter = new TypeDetailsPresenter(parameter.Type);
			presenter.TypeModified += new EventHandler((o, e) => { if (ParameterModified != null) ParameterModified(this, EventArgs.Empty); });
			AddChildPresenter(presenter, (view, childView) => view.TypeView = childView, true);
			UpdateView(view => view.Parameter = parameter);

			return base.Initialize();
		}
	}
}
