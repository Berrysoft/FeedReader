using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace FeedReader.Shared
{
    public class ExternLink : ComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            /*
             * <span style="cursor: pointer" @onclick="OnClick">
             *     @ChildContent
             * </span>
             */
            builder.OpenElement(0, Tag);
            builder.AddMultipleAttributes(1, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<IEnumerable<KeyValuePair<string, object>>>(InputAttributes!));
            if (Uri != null)
            {
                builder.AddAttribute(2, "style", "cursor: pointer");
            }
            builder.AddAttribute(3, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, OnElementClick));
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public string Tag { get; set; } = "a";

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string? Uri { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? InputAttributes { get; set; }

        private Task OnElementClick(MouseEventArgs args)
        {
            if (Uri != null)
            {
                ProcessStartInfo info = new ProcessStartInfo(Uri);
                info.UseShellExecute = true;
                Process.Start(info);
            }
            return OnClick.InvokeAsync(args);
        }
    }
}
