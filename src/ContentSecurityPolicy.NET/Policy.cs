using System.ComponentModel;

namespace ContentSecurityPolicy.NET
{
    public enum Policy
    {
        [Description(PolicyPreffix.DefaultSrc)]
        DefaultSrc,

        [Description(PolicyPreffix.ScriptSrc)]
        ScriptSrc,

        [Description(PolicyPreffix.StyleSrc)]
        StyleSrc,

        [Description(PolicyPreffix.ImgSrc)]
        ImgSrc,

        [Description(PolicyPreffix.ConnectSrc)]
        ConnectSrc,

        [Description(PolicyPreffix.FontSrc)]
        FontSrc,

        [Description(PolicyPreffix.ObjectSrc)]
        ObjectSrc,

        [Description(PolicyPreffix.MediaSrc)]
        MediaSrc,

        [Description(PolicyPreffix.FrameSrc)]
        FrameSrc,

        [Description(PolicyPreffix.Sandbox)]
        Sandbox,

        [Description(PolicyPreffix.ReportUri)]
        ReportUri,

        [Description(PolicyPreffix.ChildSrc)]
        ChildSrc,

        [Description(PolicyPreffix.FormAction)]
        FormAction,

        [Description(PolicyPreffix.FrameAncestors)]
        FrameAncestors,

        [Description(PolicyPreffix.PluginTypes)]
        PluginTypes,

        [Description(PolicyPreffix.BaseUri)]
        BaseUri,

        [Description(PolicyPreffix.ReportTo)]
        ReportTo,

        [Description(PolicyPreffix.WorkerSrc)]
        WorkerSrc,

        [Description(PolicyPreffix.ManifestSrc)]
        ManifestSrc,

        [Description(PolicyPreffix.PrefetchSrc)]
        PrefetchSrc,

        [Description(PolicyPreffix.NavigateTo)]
        NavigateTo
    }
}