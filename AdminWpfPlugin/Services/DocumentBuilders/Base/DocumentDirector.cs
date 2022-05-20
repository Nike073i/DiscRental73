namespace AdminWpfPlugin.Services.DocumentBuilders.Base
{
    public abstract class DocumentDirector
    {
        public IDocumentBuilder DocumentBuilder { get; set; }
        public abstract void Construct();
        public virtual bool CanConstruct() => DocumentBuilder is not null;
    }
}
