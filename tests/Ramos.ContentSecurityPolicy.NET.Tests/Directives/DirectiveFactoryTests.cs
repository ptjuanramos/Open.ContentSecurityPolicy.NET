using Ramos.ContentSecurityPolicy.NET.Directives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ramos.ContentSecurityPolicy.NET;

namespace Ramos.ContentSecurityPolicy.NET.Tests.Directives
{
    [TestClass]
    public class DirectiveFactoryTests
    {
        [TestMethod]
        [DataRow(Policy.DefaultSrc, PolicyPreffix.DefaultSrc)]
        [DataRow(Policy.ScriptSrc, PolicyPreffix.ScriptSrc)]
        [DataRow(Policy.StyleSrc, PolicyPreffix.StyleSrc)]
        [DataRow(Policy.ImgSrc, PolicyPreffix.ImgSrc)]
        [DataRow(Policy.ConnectSrc, PolicyPreffix.ConnectSrc)]
        [DataRow(Policy.FontSrc, PolicyPreffix.FontSrc)]
        [DataRow(Policy.ObjectSrc, PolicyPreffix.ObjectSrc)]
        [DataRow(Policy.MediaSrc, PolicyPreffix.MediaSrc)]
        [DataRow(Policy.FrameSrc, PolicyPreffix.FrameSrc)]
        [DataRow(Policy.Sandbox, PolicyPreffix.Sandbox)]
        [DataRow(Policy.ReportUri, PolicyPreffix.ReportUri)]
        [DataRow(Policy.ChildSrc, PolicyPreffix.ChildSrc)]
        [DataRow(Policy.FormAction, PolicyPreffix.FormAction)]
        [DataRow(Policy.FrameAncestors, PolicyPreffix.FrameAncestors)]
        [DataRow(Policy.PluginTypes, PolicyPreffix.PluginTypes)]
        [DataRow(Policy.BaseUri, PolicyPreffix.BaseUri)]
        [DataRow(Policy.ReportTo, PolicyPreffix.ReportTo)]
        [DataRow(Policy.WorkerSrc, PolicyPreffix.WorkerSrc)]
        [DataRow(Policy.ManifestSrc, PolicyPreffix.ManifestSrc)]
        [DataRow(Policy.PrefetchSrc, PolicyPreffix.PrefetchSrc)]
        [DataRow(Policy.NavigateTo, PolicyPreffix.NavigateTo)]
        public void GetDirectiveMustReturnRespectiveInstance(Policy policy, string preffix)
        {
            string[] values = { "value-1", "value-2", "value-3" };

            Directive directive = DirectiveFactory.GetDirective(policy, values);
            Directive selfDirective = DirectiveFactory.GetDirective(policy);

            Assert.AreEqual($"{preffix} {string.Join(Constants.Space, values)}", directive.ToString());
            Assert.AreEqual($"{preffix} self", selfDirective.ToString());
        }
    }
}
