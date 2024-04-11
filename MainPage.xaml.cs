namespace MorseCoder
{
    public partial class MainPage : ContentPage
    {
        private string currentMorseCode = "";
        private string currentWord = ""; // New variable to accumulate Morse code for the current word

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnDotClicked(object sender, EventArgs e)
        {
            AddMorseCode(".");
        }

        private void OnDashClicked(object sender, EventArgs e)
        {
            AddMorseCode("-");
        }

        private void OnSpaceClicked(object sender, EventArgs e)
        {
            // Check if the last character is already a space to determine if it's a new letter or a new word
            if (currentMorseCode.EndsWith(" / ")) // Adjusted to match the updated logic for word separation
            {
                TranslateCurrentWord();
                textOutput.Text += " "; // Add space between words
                currentWord = ""; // Reset current word
            }
            else if (!currentMorseCode.EndsWith(" ")) // To ensure we don't add extra spaces
            {
                currentMorseCode += " "; // Single space for end of a letter
                TranslateCurrentWord();
            }
            else
            {
                currentMorseCode += "/ "; // Double spaces for a new word, represented as " / "
            }

            morseInputDisplay.Text = currentMorseCode;
        }

        private void AddMorseCode(string code)
        {
            currentMorseCode += code;
            currentWord += code; // Add code to the current word
            morseInputDisplay.Text = currentMorseCode;
        }

        private void TranslateCurrentWord()
        {
            if (currentWord.Length > 0)
            {
                char translatedChar = Morse.MorseCoder(currentWord.Trim());
                textOutput.Text += translatedChar;
                currentWord = ""; // Reset the current word accumulator
            }
        }
    }

}
