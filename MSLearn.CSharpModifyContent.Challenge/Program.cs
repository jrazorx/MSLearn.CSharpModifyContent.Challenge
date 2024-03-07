/*
Begin adding your solution code to the starter code under the comment // Your work here.

Set the quantity variable to the value obtained by extracting the text between the <span> and </span> tags.

Set the output variable to the value of input, then remove the <div> and </div> tags.

Replace the HTML character ™ (&trade;) with ® (&reg;) in the output variable.

Run your solution and verify the output put matches the expected output.
Quantity: 5000
Output: <h2>Widgets &reg;</h2><span>5000</span>
*/

using System.Diagnostics;

const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

string quantity = "";
string output = "";

// Your work here
string[] divTag         = { "<div>" , "</div>"  };
string[] h2Tag          = { "<h2>"  , "</h2>"   };
string[] spanTag        = { "<span>", "</span>" };
string[] currentTag     = new string[2];
int[] currentTagLengths = new int[2];

int openingTagIndex = 0;
int closingTagIndex = 0;

// Set the quantity variable to the value obtained by extracting the text between the <span> and </span> tags.
// Initialization
currentTag = spanTag;
for (int i = 0; i < currentTag.Length; i++)
{
    currentTagLengths[i] = currentTag[i].Length;
}

openingTagIndex = input.IndexOf(currentTag[0]);
if (openingTagIndex != -1)
{
    closingTagIndex = input.IndexOf(currentTag[1]);
    if (closingTagIndex != -1)
        quantity = "Quantity: " + input.Substring(openingTagIndex + currentTagLengths[0], closingTagIndex - (openingTagIndex + currentTagLengths[0]));
}

// Set the output variable to the value of input, then remove the <div> and </div> tags.
// Initialization
currentTag = divTag;
output = input;

// Suppression du premier <div> et du premier </div> rencontrés
for (int i = 0; i< currentTag.Length; i++)
{
    int currentTagIndex = output.IndexOf(currentTag[i]);
    if (currentTagIndex != -1)
    {
        currentTagLengths[i] = currentTag[i].Length;
        output = output.Remove(currentTagIndex, currentTag[i].Length);
    }
}

// Replace the HTML character ™ (&trade;) with ® (&reg;) in the output variable.
output = "Output: " + output.Replace("&trade;", "&reg;");

Console.WriteLine(quantity);
Console.WriteLine(output);