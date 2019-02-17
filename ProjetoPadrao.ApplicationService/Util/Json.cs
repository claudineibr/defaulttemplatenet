namespace ProjetoPadrao.ApplicationService.Util
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class Json
    {
        public static string ToJson(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(
                    obj,
                    Formatting.None,
                    new JsonSerializerSettings()
                    {
                        Error = delegate(object sender, ErrorEventArgs args)
                        {
                            args.ErrorContext.Handled = true;
                        },
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
