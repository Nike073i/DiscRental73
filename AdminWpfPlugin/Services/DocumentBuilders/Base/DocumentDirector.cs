namespace AdminWpfPlugin.Services.DocumentBuilders.Base
{
    public abstract class DocumentDirector
    {
        public IDocumentBuilder DocumentBuilder { get; set; }
        public abstract bool Construct(string path, object data);
        public virtual bool CanConstruct() => DocumentBuilder is not null;
    }
}
