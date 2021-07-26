using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentSecurityPolicy.NET
{
    public record ContentSecurityPolicyHeader
    {
        public string DefaultSrc { get; set; }
        public string ScriptSrc { get; set; }
        public string StyleSrc { get; set; }
        public string ImgSrc { get; set; }
        public string ConnectSrc { get; set; }
        public string FontSrc { get; set; }
        public string ObjectSrc { get; set; }
        public string MediaSrc { get; set; }
        public string FrameSrc { get; set; }
        public string Sandbox { get; set; }
        public string ReportUri { get; set; }
        public string ChildSrc { get; set; }
        public string FormAction { get; set; }
        public string FrameAncestors { get; set; }
        public string PluginTypes { get; set; }
        public string BaseUri { get; set; }
        public string ReportTo { get; set; }
        public string WorkerSrc { get; set; }
        public string ManifestSrc { get; set; }
        public string PrefetchSrc { get; set; }
        public string NavigateTo { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
