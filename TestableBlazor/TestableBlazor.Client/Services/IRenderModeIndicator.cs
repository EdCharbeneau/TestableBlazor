namespace TestableBlazor.Client.Services
{
    public interface IRenderModeIndicator
    {
        bool IsWebassemblyReady { get; }

    }

    public class ServerRenderModeIndicator : IRenderModeIndicator
    {
        public bool IsWebassemblyReady => false;
    }

    public class WebassemblyRenderModeIndicator : IRenderModeIndicator
    {
        public bool IsWebassemblyReady => true;
    }
}
