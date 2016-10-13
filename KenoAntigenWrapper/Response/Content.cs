namespace KenoAntigenWrapper.Response
{
    public class Content
    {
        public string clientCode { get; set; }
        public string data { get; set; }

        #region Registration and login fields
        public string loginStage { get; set; }
        public string username { get; set; }
        #endregion
    }
}