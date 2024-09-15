Stopping all audio

#StopSound Sound
#StopSound Music

Clearing All Images
#ClearImage Background 
#ClearImage LeftExpression 
#ClearImage RightExpression 

#SetImage Background Backgrounds/Kitchen1_Day
Background Kitchen

#SetImage CG Characters/Faye/Faye-neutral_Right


#SetImage LeftExpression Characters/Faye/Right/Neutral
Faye: Faye Left Neutral
#SetImage LeftExpression Characters/Faye/Right/Neutral
Faye: Faye Left Afraid
#SetImage LeftExpression Characters/Faye/Right/Neutral
Faye: Faye Left Confused
#SetImage LeftExpression Characters/Faye/Right/Neutral
Faye: Faye Left Pleased

#SetImage RightExpression Characters/Faye/Right/Neutral
Faye: Faye Right Neutral
#SetImage RightExpression Characters/Faye/Right/Neutral
Faye: Faye Right Afraid
#SetImage RightExpression Characters/Faye/Right/Neutral
Faye: Faye Right Confused
#SetImage RightExpression Characters/Faye/Right/Neutral
Faye: Faye Right Pleased


#SetImage RightExpression Characters/Faye/Faye-neutral_Left
Faye: Faye Right

#ClearImage LeftExpression
Cleared Left

#ClearImage LeftExpression
Cleared Right
-> END

=== Dream1 ===
#PlaySound Sound Audio/WalkWood
// need to add pause timer
#SetImage Background Backgrounds/Bedroom1_Night
Mom?
#SetImage LeftExpression Characters/Faye/Faye-neutral_Right
Faye: .... Hello?
Faye: Was that you?
#ClearImage LeftExpression 
You listen for a response.... 
- #PlaySound Music Audio/HellscapeAmbience
....
....
The house creaks and groans.
But, no human response....
#SetImage LeftExpression Characters/Faye/Faye-afraid_Right
Faye: Maybe I should check on her.
+ [Get up?]
    Faye: I..hear you. 
    Faye: Is someone there?
    Faye: Ddd....  
    Faye: Don't mess with... m..
    
+ [Try to go back to sleep?]
    #SetImage LeftExpression Characters/Faye/Faye-neutral_Right
    Faye: Its just an old house. I should try and get some sleep.
    Faye: Sleep.
    Faye: Ya know sleep. 
    Faye: That thing you never get enough of.
    Faye: Just sleep.    
    #SetImage LeftExpression Characters/Faye/Faye-confused_Right
    Faye: .....    
    Faye: Sigh.... Not happening.    
    #SetImage LeftExpression Characters/Faye/Faye-neutral_Right
    Faye: Hello?
- Faye: Mom?
- Faye: ....
- #SetImage LeftExpression Characters/Faye/Faye-afraid_Right
- Faye: Mom? Is that you?
- Faye: NO! 
- Faye: Wait!!!
- #StopSound Music Audio/HellscapeAmbience
- #PlaySound Sound Audio/OneshotG
- #ClearImage LeftExpression 
- Suddenly, you feel a large hairy solid lump of force tackle you to the floor
- #SetImage Expression Characters/Faye/Faye-afraid_Right
- Faye: n... no.!!!
- #ClearImage LeftExpression 
- Forming words is nearl impossible.
- Thinking is damn near impossible.
- It takes all you can to focus on the sounds the of shadows moving around in the dark.
- #StopSound Sound Audio/OneshotG
- #SetImage LeftExpression Characters/Faye/Faye-afraid_Right
- Faye: h.. he ... help!!!
- #SetImage Background CG/Dream1
-> EndDemo

=== EndDemo ===
#StopSound Sound Audio/OneshotG
#ClearImage Background 
#ClearImage LeftExpression 
#SetImage Background Backgrounds/Kitchen1_Day
#PlaySound Sound Audio/Morning

The the next morning you are awakend by a large wet tounge lapping your face.

Opening your eyes you see a familary and healthy sized furry gentleman coming to greet you good morning.

#SetImage LeftExpression Characters/Faye/Faye-pleased
Faye: OHHH
Faye: Was all that you Doug?
#ClearImage LeftExpression 

You wipe off the doggy kisses from your face and muddy paw prints off from your pants.

Some time later.. 

You find a note left by Mom.
#SetImage Portrait_Right Characters/Mom/mom_full_right

Mom: Hey Fay-Fay. Had to leave out early this morning. Got a call from the foreman about the plant having issues and all seniors had to attend to. 
Mom: Left you some money and a list on the counter. 
Mom: Make sure you pick up some groceries on your way home.
Mom: See you when I get home.
#ClearImage Portrait_Right 
#SetImage LeftExpression Characters/Faye/Faye-pleased_Right
#SetImage Portrait_Right Characters/Faye/Faye_full_Right
Faye: Of course thats all it was... 
Faye: At least no one saw that...
Faye: Cept you my furry neighbor boy!
#StopSound Sound Audio/Morning
Faye: Hmmm....
Faye: ...
Faye: How did Dougie get out?
Faye: Hmmmmmmmmm.... 
Faye: ...
Faye: And I was sure I saw someone.
Faye: I'll take you back to Miss Yarbro on my walk to school this morning. How does that sound Dougie.
Faye: My giant furry commando!
Faye: ............
Faye: Maybe it was just the nerves.
#ClearImage LeftExpression 
End
-> END
