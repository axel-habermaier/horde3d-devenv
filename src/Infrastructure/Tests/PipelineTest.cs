using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.Core.Resources;

namespace Tests
{
	[TestClass]
	public class PipelineTest
	{
		public PipelineTest()
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

		public PipelineResource Pipeline { get; set; }

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
			Pipeline = new PipelineResource(1);
			Pipeline.FileContent = Properties.Resources.TestPipeline;
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException), "The FileContent property must not be empty.")]
		public void PipelineLoadFromEmptyXml()
		{
			Pipeline.FileContent = String.Empty;
			Pipeline.LoadFromXml();
		}

		[TestMethod]
		public void PipelineLoadFromXml()
		{
			Pipeline.LoadFromXml();

			Assert.IsNotNull(Pipeline.RenderTargets, "Render Targets should not be null.");
			Assert.AreEqual(3, Pipeline.RenderTargets.Count, "Wrong render target count.");

			// Check render targets.
			AssertExtensions.SingleListElementSatisfies(Pipeline.RenderTargets, rt => rt.Name == "SCENE", "Render target 'SCENE' not found.");
			AssertExtensions.SingleListElementSatisfies(Pipeline.RenderTargets, rt => rt.Name == "DISTORTION", "Render target 'DISTORTION' not found.");
			AssertExtensions.SingleListElementSatisfies(Pipeline.RenderTargets, rt => rt.Name == "DEPTH", "Render target 'DEPTH' not found.");

			// Check render target 'SCENE'
			var sceneTarget = Pipeline.RenderTargets.Where(rt => rt.Name == "SCENE").SingleOrDefault();

			Assert.IsTrue(sceneTarget.UseDepthBuffer, "Render target 'SCENE', UseDepthBuffer");
			Assert.AreEqual(1, sceneTarget.NumColorBuffers, "Render target 'SCENE', NumColorBuffers");
			Assert.AreEqual(PixelFormat.RGBA8, sceneTarget.PixelFormat, "Render target 'SCENE', PixelFormat");
			Assert.AreEqual(1.0f, sceneTarget.Scale, 0.01f, "Render target 'SCENE', Scale");
			Assert.AreEqual(16, sceneTarget.MaxSamples, "Render target 'SCENE', MaxSamples");
			Assert.AreEqual(0, sceneTarget.Width, "Render target 'SCENE', Width");
			Assert.AreEqual(0, sceneTarget.Height, "Render target 'SCENE', Height");

			// Check render target 'DISTORTION'
			var distortionTarget = Pipeline.RenderTargets.Where(rt => rt.Name == "DISTORTION").SingleOrDefault();

			Assert.IsFalse(distortionTarget.UseDepthBuffer, "Render target 'DISTORTION', UseDepthBuffer");
			Assert.AreEqual(1, distortionTarget.NumColorBuffers, "Render target 'DISTORTION', NumColorBuffers");
			Assert.AreEqual(PixelFormat.RGBA8, distortionTarget.PixelFormat, "Render target 'DISTORTION', PixelFormat");
			Assert.AreEqual(1.0f, distortionTarget.Scale, 0.01f, "Render target 'DISTORTION', Scale");
			Assert.AreEqual(0, distortionTarget.MaxSamples, "Render target 'DISTORTION', MaxSamples");
			Assert.AreEqual(0, distortionTarget.Width, "Render target 'DISTORTION', Width");
			Assert.AreEqual(0, distortionTarget.Height, "Render target 'DISTORTION', Height");

			// Check render target 'DEPTH'
			var depthTarget = Pipeline.RenderTargets.Where(rt => rt.Name == "DEPTH").SingleOrDefault();

			Assert.IsTrue(depthTarget.UseDepthBuffer, "Render target 'DEPTH', UseDepthBuffer");
			Assert.AreEqual(1, depthTarget.NumColorBuffers, "Render target 'DEPTH', NumColorBuffers");
			Assert.AreEqual(PixelFormat.RGBA16F, depthTarget.PixelFormat, "Render target 'DEPTH', PixelFormat");
			Assert.AreEqual(1.0f, depthTarget.Scale, 0.01f, "Render target 'DEPTH', Scale");
			Assert.AreEqual(0, depthTarget.MaxSamples, "Render target 'DEPTH', MaxSamples");
			Assert.AreEqual(0, depthTarget.Width, "Render target 'DEPTH', Width");
			Assert.AreEqual(0, depthTarget.Height, "Render target 'DEPTH', Height");
		}

		[TestMethod]
		public void PipelineGenerateXml()
		{
			Pipeline.LoadFromXml();
			Pipeline.GenerateXml();
		}
	}
}
