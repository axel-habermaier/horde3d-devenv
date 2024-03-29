using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.Core.Resources;

namespace Tests
{
	[TestClass]
	public class ShaderTest
	{
		public ShaderTest()
		{
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		public ShaderResource Shader { get; set; }

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestInitialize()]
		public void InitializeShader()
		{
			Shader = new ShaderResource(1);
			Shader.FileContent = Properties.Resources.TestShader;
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException), "The FileContent property must not be empty.")]
		public void ShaderLoadFromEmptyXml()
		{
			Shader.FileContent = String.Empty;
			Shader.LoadFromXml();
		}

		[TestMethod]
		public void ShaderLoadFromXml()
		{
			Shader.LoadFromXml();

			// Verify FX section and shader sections created and all shader sections loaded.
			Assert.IsNotNull(Shader.FxSection, "FxSection not created.");
			Assert.IsNotNull(Shader.ShaderSections, "ShaderSections not created.");
			Assert.AreEqual(3, Shader.ShaderSections.Count);

			// Verify that the shader sections have the correct name.
			AssertExtensions.SingleListElementSatisfies(Shader.ShaderSections, s => s.Name == "VS_GENERAL", "Shader section VS_GENERAL not found.");
			AssertExtensions.SingleListElementSatisfies(Shader.ShaderSections, s => s.Name == "FS_ATTRIBPASS", "Shader section FS_ATTRIBPASS not found.");
			AssertExtensions.SingleListElementSatisfies(Shader.ShaderSections, s => s.Name == "FS_AMBIENT", "Shader section FS_AMBIENT not found.");

			// Verify that all shader sections do not have empty code.
			AssertExtensions.ListSatisfies(Shader.ShaderSections, s => !String.IsNullOrEmpty(s.Code), s => s.Name, "Shader section contains empty code.");

			// Verify that all contexts have been found and correctly named.
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "ATTRIBPASS", "Context ATTRIBPASS not found.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "AMBIENT", "Context AMBIENT not found.");

			// Verify that all contexts have vertex and fragment shader sections.
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "ATTRIBPASS" && c.VertexShader != null, "Context ATTRIBPASS has no vertex shader.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "ATTRIBPASS" && c.FragmentShader != null, "Context ATTRIBPASS has no fragment shader.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "AMBIENT" && c.VertexShader != null, "Context AMBIENT has no vertex shader.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "AMBIENT" && c.FragmentShader != null, "Context AMBIENT has no fragment shader.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "ATTRIBPASS" && c.VertexShader.Name == "VS_GENERAL", "Context ATTRIBPASS has wrong vertex shader.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "ATTRIBPASS" && c.FragmentShader.Name == "FS_ATTRIBPASS", "Context ATTRIBPASS has wrong fragment shader.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "AMBIENT" && c.VertexShader.Name == "VS_GENERAL", "Context AMBIENT has wrong vertex shader.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "AMBIENT" && c.FragmentShader.Name == "FS_AMBIENT", "Context AMBIENT has wrong fragment shader.");

			// Verify that the render configs have been loaded correctly.
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "ATTRIBPASS" && c.RenderConfig != null, "Context ATTRIBPASS: RenderConfig property must not be null.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Contexts, c => c.Name == "AMBIENT" && c.RenderConfig != null, "Context AMBIENT: RenderConfig property must not be null.");

			var renderConfig = Shader.FxSection.Contexts.Where(c => c.Name == "AMBIENT").SingleOrDefault().RenderConfig;

			Assert.IsFalse(renderConfig.WriteDepth, "WriteDepth should be false.");
			Assert.AreEqual(BlendMode.Mult, renderConfig.BlendMode);
			Assert.AreEqual(TestFunction.GreaterEqual, renderConfig.DepthTest);
			Assert.AreEqual(TestFunction.Less, renderConfig.AlphaTest);
			Assert.AreEqual(0.1f, renderConfig.AlphaReferenceValue, 0.01f);
			Assert.AreEqual(true, renderConfig.AlphaToCoverage);

			// Verify that all samplers have been loaded correctly.
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Samplers, s => s.Name == "albedoMap", "Sampler albedoMap not found.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Samplers, s => s.Name == "testTexture", "Sampler testTexture not found.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Samplers, s => s.Name == "testTexture" && s.TexUnit == 4, "Sampler testTexture is assigned to the wrong TexUnit.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Samplers, s => s.Name == "albedoMap" && s.TexUnit == -1, "Sampler albedoMap is assigned to the wrong TexUnit.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Samplers, s => s.Name == "albedoMap" && s.StageConfig != null, "Sampler albedoMap's stage config should be loaded.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Samplers, s => s.Name == "testTexture" && s.StageConfig != null, "Sampler testTexture's stage config should be loaded.");

			var stageConfig = Shader.FxSection.Samplers.Where(s => s.Name == "albedoMap").SingleOrDefault().StageConfig;

			Assert.AreEqual(AddressMode.Clamp, stageConfig.AddressMode);
			Assert.AreEqual(FilteringMode.None, stageConfig.FilteringMode);
			Assert.AreEqual(2, stageConfig.MaxAnisotropy);

			// Verify that all uniforms have been loaded correctly.
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Uniforms, u => u.Name == "modulate", "Uniform modulate not found.");
			AssertExtensions.SingleListElementSatisfies(Shader.FxSection.Uniforms, u => u.Name == "data", "Uniform data not found.");

			var uniform = Shader.FxSection.Uniforms.Where(u => u.Name == "modulate").SingleOrDefault();
			Assert.AreEqual(1.0f, uniform.A, 0.01f, "Uniform 'modulate'");
			Assert.AreEqual(0.5f, uniform.B, 0.01f, "Uniform 'modulate'");
			Assert.AreEqual(0.2f, uniform.C, 0.01f, "Uniform 'modulate'");
			Assert.AreEqual(0.4f, uniform.D, 0.01f, "Uniform 'modulate'");

			uniform = Shader.FxSection.Uniforms.Where(u => u.Name == "data").SingleOrDefault();
			Assert.AreEqual(0.0f, uniform.A, 0.01f, "Uniform 'data'");
			Assert.AreEqual(0.0f, uniform.B, 0.01f, "Uniform 'data'");
			Assert.AreEqual(0.0f, uniform.C, 0.01f, "Uniform 'data'");
			Assert.AreEqual(0.0f, uniform.D, 0.01f, "Uniform 'data'");
		}

		[TestMethod]
		public void ShaderGenerateXml()
		{
			Shader.LoadFromXml();
			Shader.GenerateXml();
		}
	}
}
