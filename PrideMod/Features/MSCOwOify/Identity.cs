namespace PrideMod.Features.MSCOwOify
{
    internal class Identity
    {
        internal static readonly string[] Identities = { "Woman", "Femboy", "TransGirl", "TransBoy", "Enby" };

        public static string ConvertIdentityInSentence(string text)
        {
            // man, male, boy replace
            if (!MscOwOify.reidentifier.GetValue()) return text;

            switch (Identities[MscOwOify.identity.GetSelectedItemIndex()])
            {
                case "Woman":
                {
                    text = text.Replace("man", "woman");
                    text = text.Replace("male", "female");
                    text = text.Replace("boy", "girl");
                    break;
                }
                case "Femboy":
                {
                    text = text.Replace("man", "femboy");
                    text = text.Replace("male", "femboy");
                    text = text.Replace("boy", "femboy");
                    break;
                }
                case "TransGirl":
                {
                    text = text.Replace("man", "transfem");
                    text = text.Replace("male", "transfem");
                    text = text.Replace("boy", "trans girl");
                    break;
                }
                case "TransBoy":
                {
                    text = text.Replace("man", "transmasc");
                    text = text.Replace("male", "transmasc");
                    text = text.Replace("boy", "trans boy");
                    break;
                }
                case "Enby":
                {
                    text = text.Replace("man", "enby");
                    text = text.Replace("male", "enby");
                    text = text.Replace("boy", "enby");
                    break;
                }
            }

            return text;
        }

    }
}