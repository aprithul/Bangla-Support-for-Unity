# Bangla-Support-for-Unity
A 'work in progress' solution for showing and inputting Bangla and English  text in both editor and in game.

Since Unity can't show complex Bangla scripts with Unicode, the only way to show bangla in Unity is to use an ANSII font.Although it works,
the existing ANSII fonts for Bangla can't show English text in the same text component, because they don't contain the required gliphs.
Moreover, I don't know of any way for inputting Bangla text in-game with it.

Another approach would be to write a custom unicode text renderer or use an existing one. The problem is Unity isn't open source and thus doesn't allow us 
to use our own text renderer ( as far as I know ). So to use a custom font renderer, we will have to make our custom text component too. 
Although it will enable usage of any Unicode font, these seems to be way too much work. 

This project uses an ANSII font based system to display both Bangla and English. The English glyphs have been copied over from the font's Unicode
counterpart. For inputting Bangla text, I have used JAvroPhonetic v1.2. The jar of the project (with all its dependencies included) has been 
converted with ikvm to a dll.

USAGE:
The software is not ready for production use at the moment. It's still probably missing some of the 'juktoborno's. However if you want to
test what's already been done, download the Unity project. The only scene presetn now is the Test Scene. Open the scene. Here's what you can do:
1. Select the text component under Canvas from the project hierarchy.
2. Click on your scene window header ( This needs to be done now since the user input is captured in OnSceneGUI, needs to be changed for usabilities sake )
2. Start typing as you would do with avro phonetically. The text field should show proper bangla text. 
3. To switch from Bangla to English press ctrl+alt+F7 .

FAQ:
Q: So can I change fonts?
A: Yes and No. It only works with ANSII fonts as stated earlier. There are only two ANSII fonts available now as per my knowledge, both provided by the awesome guys at omicronlab. But I had to modify those to enable rendering of English as well. So the simple answer is, if you can make your own ANSII font, then yes you can change fonts. But unicode fonts out of the box won't work. 

Q: Why didn't you put the language rules/unicode to ansii dictionaries in a text/xml/json/whatever file?
A: It's just faster for me to work with. Maybe I will copy them over at a later stage. Not feeling the need at the moment really.

[ It is a work in progress so please have patience :) ]
