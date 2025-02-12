using Microsoft.AspNetCore.Components;

namespace FrontEnd
{
    [EventHandler("ondocumentclick", typeof(DocumentClickEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    public static class EventHandlers
    {
    }

    public class DocumentClickEventArgs : EventArgs
    {
        public string? DocumentClickProperty1 { get; set; }
        public string? DocumentClickProperty2 { get; set; }
    }
}
