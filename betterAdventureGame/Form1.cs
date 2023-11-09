using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace betterAdventureGame
{
    public partial class Form1 : Form
    {
        Dictionary<string, string[]> dict = new Dictionary<string, string[]>() {
                { "Restart", new string[]{ "You find yourself standing at the edge of a mysterious and enchanting forest. The path diverges into two, and you must make a choice.", "Follow the path on the left.", "Follow the path on the right."}},
                {"Follow the path on the left.",new string[]{ "You venture deeper into the forest on the left path. The trees seem to close in around you. After a while, you stumble upon a hidden clearing with a magical pond.", "Drink from the pond.","Ignore the pond and continue your journey."}},
                {"Drink from the pond.",new string[]{ "You drink from the pond and feel rejuvenated. You continue your journey with newfound energy. You discover a treasure chest hidden beneath the roots of a massive tree.", "Open the treasure chest.", "Ignore the treasure chest and keep walking."}},
                {"Open the treasure chest.",new string[]{ "You decide to open the treasure chest. It contains a valuable gem and a map to another part of the forest. You head there.", "You follow the map and find a portal that transports you to another world.", "You keep the gem and stay in the forest."}},
                {"You follow the map and find a portal that transports you to another world.",new string[]{ "In this new world you find yourself standing at the edge of a mysterious and enchanting forest. The path diverges into two, and you must make a choice.", "Follow the path on the left.", "Follow the path on the right."}},
                {"You keep the gem and stay in the forest.",new string[]{ "Content that you've gained a vaulable gem, you continue your exploration and stumble upon a cave.", "Enter the cave.", "Walk away from the cave."}},
                {"Ignore the treasure chest and keep walking.",new string[]{ "You ignore the treasure chest and keep walking. You reach a beautiful glade.", "Rest in the glade.", "Leave the glade and continue exploring."}},
                {"Rest in the glade.",new string[]{ "You rest in the glade, but you wake up feeling disoriented. The forest has changed, and you're lost.", "Try to retrace your steps.", "Call out for help."}},
                {"Leave the glade and continue exploring.",new string[]{ "You leave the glade and continue exploring. The path becomes darker and more mysterious.", "Push forward into the darkness.", "Turn back to find your way out."}},
                {"Call out for help.",new string[]{ "You call out for help, and a helpful guide emerges to lead you back to the forest's edge.", "Thank the guide but continue exploring anyway.", "Leave the forest and never return."}},
                {"Leave the forest and never return.",new string[]{ "You eventually make it to the edge of the forest and escape.", "Restart","Quit"}},
                {"Push forward into the darkness.",new string[]{ "You push forward into the darkness, but you encounter a dangerous creature and barely escape with your life. You end up back at the glade but this time you are forced to rest there due to fatigue. ", "Rest in the glade.", "Rest in the glade."}},
                {"Try to retrace your steps.",new string[]{ "You try to remember from which way you came but nothing looks familiar. The deeper you go into the forest, the darker it gets. Gradually everything fades to darkness.", "Restart","Quit"}},
                {"Thank the guide but continue exploring anyway.",new string[]{ "You leave the glade and continue exploring. The path becomes darker and more mysterious.", "Push forward into the darkness.", "Turn back to find your way out."}},
                {"Turn back to find your way out.",new string[]{ "You try to remember from which way you came but nothing looks familiar. The deeper you go into the forest, the darker it gets. Gradually everything fades to darkness.", "Restart","Quit"}},
                {"Ignore the pond and continue your journey.",new string[]{ "You hesitate to drink and continue walking. Eventually, you come across a talking animal who offers guidance.", "Follow the talking animal.", "Ignore the talking animal."}},
                {"Follow the talking animal.",new string[]{ "You follow the animal and it leads you to a hidden village of magical creatures. The creature gestures for you to join their community.", "Join the village.","Leave because it's starting to seem like a cult."}},
                {"Join the village.",new string[]{ "You agree to join them. They make you carry out an ancient ritual. The ritual involves being taken to the top of a volcano. It turns out you were actually just a sacrifice to the Gods. They throw you into the volcano.", "Restart","Quit"}},
                {"Leave because it's starting to seem like a cult.",new string[]{ "You turn to leave but a force-field prevents you from escaping. They start to attack you. After a lot of fighting, they tie you to a wooden stake. They set it alight and chant as you burn.", "Restart","Quit"}},
                {"Ignore the talking animal.",new string[]{ "You ignore the animal's advice and choose your own way, which leads to a mysterious cave.", "Enter the cave.", "Walk away from the cave."}},
                {"Follow the path on the right.",new string[]{ "You follow the right path and encounter a talking tree that offers advice. It gives you some directions and suggest you follow them.", "Heed the tree's advice and follow its suggested path.", "Ignore the tree and choose your own way."}},
                {"Heed the tree's advice and follow its suggested path.",new string[]{ "You heed the tree's advice and follow its path. You find a hidden village of magical creatures. The creatures gesture for you to join their community.", "Join the village.", "Leave because it's starting to seem like a cult."}},
                {"Enter the cave.",new string[]{ "You enter the cave, and inside, you discover a magical treasure.", "Take the treasure.", "Leave the treasure and explore deeper into the cave."}},
                {"Walk away from the cave.",new string[]{ "You walk away from the cave and continue your journey. You encounter a peculiar glowing flower.", "Pick the flower.", "Leave the flower and keep walking."}},
                {"Ignore the tree and choose your own way.",new string[]{ "You pretend you don't hear the tree and continue your journey. You encounter a peculiar glowing flower.", "Pick the flower.", "Leave the flower and keep walking."}},
                {"Take the treasure.",new string[]{ "You open the box, it's clear that it's very old as the wood is rotting. Inside the box is a pile of gold, shinier than you ever thought was possible. From behind you, you hear \"Arrgh, get off me treasurrre!\". The pirate plunges his dagger into your back.", "Restart","Quit"}},
                {"Leave the treasure and explore deeper into the cave.",new string[]{ "You creep deeper into the cave and it keeps getting darker. Just when you are thinking about turning back, you see a light up ahead. You advance towards it. It goes as you get closer until it consumes you. You made it to the afterlife, you had a pain-free death, it wasn't the worst way to go.", "Restart","Quit"}},
                {"Pick the flower.",new string[]{ "The pick the flower but as soon as you touch it a rash starts to appear, first on your hand, then it climbs up your arm and to the rest of your body. It burns with such agony that you are relieved when everything finally goes black.", "Restart","Quit"}},
                {"Leave the flower and keep walking.",new string[]{ "You keep walking until the sun sets then set up a camp to sleep for the night. You don't wake up in the morning. No one survives a night in the forest.", "Restart","Quit"}}
        };

        public void updateText(string inp)
        {
            if (dict.Keys.Contains(inp))
            {
                string[] arr = dict[inp];
                label1.Text = arr[0];
                button1.Text = arr[1];
                button2.Text = arr[2];
            }
            else { 
                label1.Text = "Couldn't find key:"+inp;
            }
        }

        public Form1()
        {
            InitializeComponent();
            if (label1.Text == "label1")
            {
                updateText("Restart");
            }
        }

        private void btnClick(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "Quit")
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                updateText((sender as Button).Text);
            }
        }
    }
}