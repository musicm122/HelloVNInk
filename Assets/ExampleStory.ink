VAR hasHomework = true
VAR proudOfHomework = false
VAR infractions = 0

-> BusStop

=== BusStop
#SetImage Background Backgrounds/AbandonedHouse_Day

#Example Arg1 Arg2
#ClearImage Portrait
You are walking to school on an average Tuesday, when suddenly...
#SetImage Portrait Characters/Boy/Neutral1
Sam: Hey.
Oh no! A classmate! Classmates are to be avoided at all costs.
#SetImage Portrait Characters/Boy/Conflicted1
Sam: You okay?
+	[Run!]
	You bolt, hoping he didn't even notice you. -> Run
+	[Ignore him]
	You freeze and avert your gaze. You even let out a slight whistle.
	SetImage Portrait Characters/Boy/Neutral1
	Your adversary stares at you for a small eternity and blinks a few times. Afterwards, he spares you the torture and distracts himself with his phone.
	++	[Run while he isn't looking!]
		You wait patiently while keeping an eye on your challenger in your peripheral vision. Then he yawns. This is your chance!
		While he's distracted, you run. -> Run
	++	[Wait for the bus]
		Content with how things are going so far, you decide to drop your guard.
		-> Wait
+	[Make a joke]
	-> Joke

= Joke
You: What goes down but doesn't come up?
#SetImage Portrait Characters/Boy/Sad1
Sam: Huh?
You: A yo.
Sam: ... What?
You: It's a joke.
Sam: Oh. Sorry.
A small—and painful—eternity has dawned upon this battlefield.
+	[Flee!]
	A resurgence of energy springs from you! When the moment is most opportune, you dash. -> Run
+	[Wait for the bus]
	It is painful. Too painful. But that must be the burden you bare. At least for a little while.
	-> Wait

= Run
#ClearImage Portrait
<> You run as fast as you can!
-> RunToSchool

= Wait
The bus arrives not too long afterwards, allowing both you and your rival to obtain safe transport.
-> BusToSchool

=== RunToSchool
#SetImage Background Backgrounds/School_Hallway_Day
It doesn't take long before your stamina gives way, but you do manage to make it to your school. Victory is yours!
But something is missing...
Your backpack! You must of dropped it while you ran! It had your homework!
~ hasHomework = false
+	[Abandon it]
    #SetImage Background Backgrounds/Classroom_Day
	It isn't worth it. It was a casualty of war. You waltz in to class without your homework, head low, avoiding your teacher's sure ire.
	#SetImage Portrait Characters/Boy/Neutral1
	But when you arrive to the classroom, you notice your opponent from the bus stop sitting in one of the front seats. How did he make it to the classroom faster than you did?
	++	[Ask him]
		You: How did you make it here so fast? How is it possible?
		His gazes switches from the wall plaster to your eyes. You both lock into mortal combat once again, a battle of wits for all eternity.
		#SetImage Portrait Characters/Boy/Confused1
		Sam: Huh? Oh. I took the bus.
		... That makes sense.
		-> ClassStarts
	++	[Ignore him]
		:His perception is off: He doesn't seem to notice you. You pounce on the opportunity and make yourself comfy in your seat.
		-> ClassStarts
+	[Find it]
	You know what must be done.
	Calling upon all reserves of energy, you kneel on the ground, preparing to run once again. Your muscles twitch with anticipation and excitement, and you release them, moving faster than any human has before. Than any creature ever has before.
	:All gaze upon the epic potential that you demonstrate. The world becomes a blur as you become oblivious to all that which is not your query. This is the ultimate achievement of all those that came before you. But to you, this is merely the obvious finality of the universe: if the world messes with your homework, you shall find it. At all cost.
	You make it 30 feet, and you trip and fall.
	You: Ow...
	But wait... the object you tripped on... it is your backpack! You have reclaimed it at last! Who would have thought that it was so close?
	~ hasHomework = true
	#PlaySound Sound Audio/SchoolBell
	Your spell of whimsy is cut short by the school bell. You're late to class!
	-> ClassStarts.LateToClass

=== BusToSchool
#ClearImage Portrait
#SetImage Background Backgrounds/City_Morning
Throughout the bus ride, your challenger from the bus stop gazes upon his phone in an endless stare. You do something similar, elsewhere.
But a thought strikes you, freezing you solid into your seat of doom.
Your homework is only half finished!
~ hasHomework = false
+ [Finish it, quickly!]
	-> FinishHomework
+ [Ask your rival to copy]
	-> CopyHomework
+ [Accept defeat]
	Your face grows colder with the realization that there is nothing you can do. Day turns to night as the pain of winter rests upon your shoulders. Your homework is not finished, and it will remain unfinished.
	-> Exit

= FinishHomework
An awesome frenzy is unleashed upon the world, via your homework-solving skills! But your awesome power cannot be unleashed for too long, and you are tired.
You manage to finish the homework before the bus ride is over, but it is certainly lackluster.
~ hasHomework = true
~ infractions = infractions + 1
-> Exit

= CopyHomework
A bead of sweat drips down your face, followed in pursuit by another.
Your heart pounds. The drums of war. You swear that all those aboard the bus hear it. Even the bus itself.
But you must face the situation at hand. You need that homework.
#SetImage Portrait Characters/Boy/Neutral1
You begin to formulate a proper battle strategy. First, you'll ask your honor-bound combatant if you are allowed to copy his homework. Obviously, he will say "no," so you prepare your tithe. What will he ask? Lunch money? A day of servitude? Your soul? You brace for impact... you are willing to do that which is necessary. Victory at all cost.
You: Can I copy your homework?
#SetImage Portrait Characters/Boy/Angry1
The world moves in slow motion. This is it. The world's final breath before extinction. Before annihilation, before oblivion. He slowly turns towards you in this time-stopped world, the air filled with the haze of one-thousand suns. Nay, one-million. And a half.
#SetImage Portrait Characters/Boy/Smiling1
Sam: Sure. I copied mine from someone else anyways.
Victory! Your army, population one, remains yet undefeated. You copy his homework in record time. Perhaps an unethical way to win a war, but war is war.
~ hasHomework = true
~ proudOfHomework = true
-> Exit

= Exit
#ClearImage Portrait
After some time, having arrived at its destination, the bus's wheels grind to a halt.
When you depart from your chariot, you make way to the classroom, your gladiator arena.
-> ClassStarts

=== ClassStarts
#SetImage Background Backgrounds/Classroom_Day
#ClearImage Portrait
#PlaySound Sound Audio/SchoolBell
The bell tolls. Your teacher appears on stage.
-> HomeworkDue

= LateToClass
#SetImage Background Backgrounds/Classroom_Day
You slam open the door, making your triumphant and defeated presence known. As a follow-up, you calmly sit into your chair. The teacher lays her ireful gaze upon you, but allows you to rest.
~ infractions = infractions + 1
-> HomeworkDue

= HomeworkDue
And then she announces the daily schedule for all to hear, starting with a turnover of your homework.
{hasHomework:
	<> You hand over your {proudOfHomework: hard-earned spoils|hastily-made papers}. A bright{RunToSchool:, but tired,} smile catches your face.
	{BusToSchool.FinishHomework: As your teacher's eyes meet your crude and clearly-rushed papers, a small sigh escapes her lips. But she does leave you be.}
- else:
	You meekly avoid her gaze, no tithe to spare. She sighs, but does turn to other matters.
	~ infractions = infractions + 1
}
<> Your life has been spared, this once.

{BusStop.Joke:
	#SetImage Portrait Characters/Boy/Neutral1
	While the teacher collects her other tokens of appreciation, you hear a soft—but unmistakable!—mutter from your now-peaceful adversary.
	#SetImage Portrait Characters/Boy/Smiling2
	Sam: Oh... Yo-yo. I get it.
}

Other than that, your class progresses with little else of interest.
End! Try again!

// I made some paths where you can gain infractions, but they don't do anything in this story.
// Consider having the teacher give the player a "see me after class"-esque note if the player obtains too many infractions!

-> DONE