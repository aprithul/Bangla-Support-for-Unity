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

[ It is a working progress in very early stages and probably isn't usable for anything. Have patience then! ]
