using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.Resources;
using Infrastructure.Core.Resources;
using System.ComponentModel;

namespace Client.Presenters.Resources
{
	class ShaderContextPresenter : DebuggerPresenter<ShaderContextView>
	{
		public ShaderContext Context { get; private set; }

		ShaderSectionPresenter vertexShader;
		ShaderSectionPresenter fragmentShader;

		public ShaderContextPresenter(ShaderContext shaderContext)
		{
			this.Context = shaderContext;
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.ShaderContext = Context);
			AddFragmentShaderPresenter();
			AddVertexShaderPresenter();

			return base.Initialize();
		}

		private void AddVertexShaderPresenter()
		{
			if (Context.VertexShader == null)
			{
				UpdateView(view => view.ShowNoVertexShaderMessage = true);
				return;
			}

			UpdateView(view => view.ShowNoVertexShaderMessage = false);
			vertexShader = new ShaderSectionPresenter(Context.VertexShader, ShaderType.VertexShader);
			AddChildPresenter(vertexShader, (view, childView) => view.VertexShaderSectionView = childView, true);
		}

		private void AddFragmentShaderPresenter()
		{
			if (Context.FragmentShader == null)
			{
				UpdateView(view => view.ShowNoFragmentShaderMessage = true);
				return;
			}

			UpdateView(view => view.ShowNoFragmentShaderMessage = false);

			fragmentShader = new ShaderSectionPresenter(Context.FragmentShader, ShaderType.FragmentShader);
			AddChildPresenter(fragmentShader, (view, childView) => view.FragmentShaderSectionView = childView, true);
		}

		protected override bool InitializeEvents()
		{
			Context.PropertyChanged += PropertyChanged;

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			Context.PropertyChanged -= PropertyChanged;

			base.Release();
		}

		private void PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "VertexShader")
			{
				if (vertexShader != null)
					RemoveChildPresenter(vertexShader);

				AddVertexShaderPresenter();
			}
			else if (e.PropertyName == "FragmentShader")
			{
				if (fragmentShader != null)
					RemoveChildPresenter(fragmentShader);

				AddFragmentShaderPresenter();
			}
		}

		protected override bool UniqueName
		{
			get { return true; }
		}
	}
}
