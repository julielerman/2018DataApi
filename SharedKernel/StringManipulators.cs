using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StringManipulators {
  public static string ReplaceBadWordWithAsterisks (string textToCheck) {
    var badWordList = new string[] { "gorram", "tetchy", "ruttin", "go shi", "wo cao" };
    var matches = badWordList.Where (w => textToCheck.ToLower ().Contains (w));

    foreach (var match in matches) {
      textToCheck = textToCheck.ToLower ().Replace (match, new string ('*', match.Length));
    }
    return textToCheck;
  }
}