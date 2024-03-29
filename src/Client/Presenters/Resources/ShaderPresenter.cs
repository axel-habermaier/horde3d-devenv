using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.Core.Resources;
using System.IO;
using Client.Views.Resources;
using Infrastructure.UserInterface;

namespace Client.Presenters.Resources
{
	class ShaderPresenter : EditableResourcePresenter<ShaderView, ShaderResource>
	{
		Presenter<DebuggerShell> currentChildPresenter = null;
		EventHandler undoneRedoneHandler;

		public ShaderPresenter(ShaderResource shader)
			: base(shader)
		{
		}

		protected override bool Initialize()
		{
			LoadDesigner();
			UpdateView(view => view.Shader = Resource);
			AddChildPresenter(textEditor, (view, childView) => view.TextEditorView = childView);
			textEditor.TextHighlighting = SyntaxHighlighting.Cpp;
			undoneRedoneHandler = (o, e) => ReloadDesigner();

			return base.Initialize();
		}

		private void LoadDesigner()
		{
			try
			{
				// We have to unregister all property updated events and then re-register them, as some objects might have
				// been removed and/or new ones added.
				UnregisterUpdates();
				Resource.LoadFromXml();
				RegisterUpdates();
				UpdateView(view => view.DesignerEnabled = true);
				//designerEnabled = true;
			}
			catch (Exception e)
			{
				UpdateView(view => view.DesignerDisabledMessage = e.Message + Environment.NewLine + Environment.NewLine + e.StackTrace);
				UpdateView(view => view.DesignerEnabled = false);
				//designerEnabled = false;
			}
		}

		private void ReloadDesigner()
		{
			LoadDesigner();
			UpdateView(view => view.UpdateDesigner());

			if (currentChildPresenter != null)
			{
				var remove = false;

				if (currentChildPresenter is SamplerPresenter && !Resource.FxSection.Samplers.Contains((currentChildPresenter as SamplerPresenter).Sampler))
					remove = true;

				if (currentChildPresenter is ShaderContextPresenter && !Resource.FxSection.Contexts.Contains((currentChildPresenter as ShaderContextPresenter).Context))
					remove = true;

				if (currentChildPresenter is UniformPresenter && !Resource.FxSection.Uniforms.Contains((currentChildPresenter as UniformPresenter).Uniform))
					remove = true;

				if (currentChildPresenter is ShaderSectionPresenter && !Resource.ShaderSections.Contains((currentChildPresenter as ShaderSectionPresenter).Section))
					remove = true;

				if (remove)
					RemoveChildPresenter(currentChildPresenter);
			}
		}

		protected override bool InitializeEvents()
		{
			UpdateView(view => view.ShowShaderContextDetailsRequest += c => ShowChildPresenter(new ShaderContextPresenter(c)));
			UpdateView(view => view.ShowShaderSectionDetailsRequest += s => ShowChildPresenter(new ShaderSectionPresenter(s)));
			UpdateView(view => view.ShowSamplerDetailsRequest += s => ShowChildPresenter(new SamplerPresenter(s)));
			UpdateView(view => view.ShowUniformDetailsRequest += u => ShowChildPresenter(new UniformPresenter(u)));
			UpdateView(view => view.SwitchToDesignerRequest += () => ReloadDesigner());
			Shell.CommandDispatcher.Undone += undoneRedoneHandler;
			Shell.CommandDispatcher.Redone += undoneRedoneHandler;

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			Shell.CommandDispatcher.Undone -= undoneRedoneHandler;
			Shell.CommandDispatcher.Redone -= undoneRedoneHandler;
			UnregisterUpdates();
			
			base.Release();
		}

		private void ShowChildPresenter<TView>(DebuggerPresenter<TView> presenter)
			where TView : UserControlView, new()
		{
			UnregisterUpdates();
			if (currentChildPresenter != null)
				RemoveChildPresenter(currentChildPresenter);

			currentChildPresenter = presenter;
			AddChildPresenter<TView>(presenter, (view, childView) => view.DetailsView = childView, true);
			RegisterUpdates();
		}

		private void UnregisterUpdates()
		{
			if (Resource.ShaderSections != null)
				Resource.ShaderSections.Foreach(s => s.PropertyUpdated -= ResourcePropertyUpdated);

			if (Resource.FxSection == null)
				return;

			Resource.FxSection.Contexts.Foreach(c =>
			{
				c.PropertyUpdated -= ResourcePropertyUpdated;
				c.RenderConfig.PropertyUpdated -= ResourcePropertyUpdated;
			});

			Resource.FxSection.Samplers.Foreach(s =>
			{
				s.PropertyUpdated -= ResourcePropertyUpdated;
				s.StageConfig.PropertyUpdated -= ResourcePropertyUpdated;
			});

			Resource.FxSection.Uniforms.Foreach(u => u.PropertyUpdated -= ResourcePropertyUpdated);
		}

		private void RegisterUpdates()
		{
			if (currentChildPresenter is ShaderSectionPresenter && Resource.ShaderSections != null)
				Resource.ShaderSections.Foreach(s => s.PropertyUpdated += ResourcePropertyUpdated);

			if (Resource.FxSection == null)
				return;

			if (currentChildPresenter is ShaderContextPresenter)
			{
				Resource.FxSection.Contexts.Foreach(c =>
				{
					c.PropertyUpdated += ResourcePropertyUpdated;
					c.RenderConfig.PropertyUpdated += ResourcePropertyUpdated;
				});

				var contextPresenter = currentChildPresenter as ShaderContextPresenter;

				if (contextPresenter.Context.FragmentShader != null)
					contextPresenter.Context.FragmentShader.PropertyUpdated += ResourcePropertyUpdated;

				if (contextPresenter.Context.VertexShader != null)
					contextPresenter.Context.VertexShader.PropertyUpdated += ResourcePropertyUpdated;
			}

			if (currentChildPresenter is SamplerPresenter)
			{
				Resource.FxSection.Samplers.Foreach(s =>
				{
					s.PropertyUpdated += ResourcePropertyUpdated;
					s.StageConfig.PropertyUpdated += ResourcePropertyUpdated;
				});
			}

			if (currentChildPresenter is UniformPresenter)
				Resource.FxSection.Uniforms.Foreach(u => u.PropertyUpdated += ResourcePropertyUpdated);
		}
	}
}
