using System;

class Program
{
    static void Main()
    {
        TwentyOne game = new TwentyOne();
        game.Start();
    }
}

enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

class TwentyOne
{
    private Deck deck;
    private Player player;
    private Dealer dealer;

    public void Start()
    {
        while (true)
        {
            InitializeGame();

            // Start Player Turn
            bool playerStayed = player.PlayTurn();

            // Start Dealer Turn
            bool dealerStayed = dealer.PlayTurn();

            // see who wins
            DetermineRoundWinner();

            if (playerStayed && dealerStayed)
            {
                // End game if both of them stay
                break;
            }
        }
    }

    private void InitializeGame()
    {
        deck = new Deck();
        player = new Player(deck);
        dealer = new Dealer(deck);

        player.AddCard(deck.DrawCard());
        player.AddCard(deck.DrawCard());
        dealer.AddCard(deck.DrawCard());
        //draw a hidden card and do not reveal it
        dealer.AddHiddenCard(deck.DrawCard(true));
    }

    private void DetermineRoundWinner()
    {
        Console.WriteLine("\nROUND OVER");

        Console.WriteLine($"Player's hand: {player.GetHandValue()}");
        Console.WriteLine($"Dealer's hand: {dealer.GetHandValue()} (Face-down card: {dealer.GetFaceDownCard()})");

        //whoever has the larger value hand that is below the number 21 wins
        if (player.GetHandValue() > 21 || (dealer.GetHandValue() <= 21 && dealer.GetHandValue() >= player.GetHandValue()))
        {
            Console.WriteLine("Dealer wins!");
        }
        else
        {
            Console.WriteLine("Player wins!");
        }
    }
}

class Card
{
    public Suit Suit { get; }
    public string Rank { get; }

    public Card(Suit suit, string rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}

class Deck
{
    private List<Card> cards;
    private Random random;

    public Deck()
    {
        InitializeDeck();
        Shuffle();
    }

    private void InitializeDeck()
    {
        cards = new List<Card>();

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string rank in ranks)
            {
                cards.Add(new Card(suit, rank));
            }
        }

        random = new Random();
    }

    public void Shuffle()
    {
        cards = cards.OrderBy(c => random.Next()).ToList();
    }

    public Card DrawCard(bool faceDown = false)
    {
        Card drawnCard = cards[0];
        cards.RemoveAt(0);

        if (!faceDown)
        {
            Console.WriteLine($"Card drawn: {drawnCard}");
        }

        else
        {
            Console.WriteLine("Card drawn: [Unkown]");
        }

        return drawnCard;
    }
}

class Player
{
    //dont change these for the match
    protected List<Card> hand;
    protected Deck deck;

    public Player(Deck deck)
    {
        hand = new List<Card>();
        this.deck = deck;
    }

    public void AddCard(Card card)
    {
        hand.Add(card);
        Console.WriteLine($"Player receives: {card}");
    }

    public int GetHandValue()
    {
        int value = 0;

        foreach (Card card in hand)
        {
            //Ace = 11
            if (card.Rank == "Ace")
            {
                value += 11;
            }

            //King/Queen/Jack = 10
            else if (card.Rank == "King" || card.Rank == "Queen" || card.Rank == "Jack")
            {
                value += 10;
            }

            else
            {
                value += int.Parse(card.Rank);
            }
        }
        return value;
    }

    public bool PlayTurn()
    {
        while (true)
        {
            Console.WriteLine($"\nPlayer's hand: {GetHandValue()}");

            Console.Write("Do you want to (H)it or (S)tay? ");
            string input = Console.ReadLine().ToUpper();

            if (input == "H")
            {
                AddCard(deck.DrawCard());

                //see if player went over 21
                if (GetHandValue() > 21)
                {
                    Console.WriteLine("Player went over 21! Dealer wins.");
                    return true; // Player's turn is over
                }
            }

            else if (input == "S")
            {
                Console.WriteLine("Player chooses to stay.");
                return true; // Player's turn is over
            }

            //please dont type something invalid
            else
            {
                Console.WriteLine("Invalid input. Please enter 'H' or 'S'.");
            }
        }
    }
}


//This whole class is the same as Player
class Dealer
{
    private List<Card> hand;
    private Deck deck;
    private Random random;

    public Dealer(Deck deck)
    {
        hand = new List<Card>();
        this.deck = deck;
        random = new Random();
    }

    public void AddCard(Card card)
    {
        hand.Add(card);
        Console.WriteLine($"Dealer receives: {card}");
    }

    public void AddHiddenCard(Card card)
    {
        hand.Add(card);
        Console.WriteLine("Dealer receieves: [Unknown]");
    }

    public int GetHandValue()
    {
        int value = 0;

        foreach (Card card in hand)
        {
            //Ace still = 11
            if (card.Rank == "Ace")
            {
                value += 11;
            }

            //King/Queen/Jack = 10
            else if (card.Rank == "King" || card.Rank == "Queen" || card.Rank == "Jack")
            {
                value += 10;
            }

            else
            {
                value += int.Parse(card.Rank);
            }
        }


        return value;
    }

    public string GetFaceDownCard()
    {
        return hand[1].ToString(); // Returns the face-down card
    }

    public bool PlayTurn()
    {
        Console.WriteLine("\nDealer's turn:");

        // Reveal facedown card
        Console.WriteLine($"Face-down card: {GetFaceDownCard()}");

        while (GetHandValue() < 17)
        {
            Console.WriteLine("Dealer chooses to hit.");
            AddCard(deck.DrawCard());

        }

        if (random.Next(1, 101) <= 80)
        {
            Console.WriteLine("Dealer chooses to stay.");
        }

        else
        {
            Console.WriteLine("Dealer chooses to hit.");
            AddCard(deck.DrawCard());
        }

        //in case the dealer's hand goes over 21
        if (GetHandValue() > 21)
        {
            Console.WriteLine("Dealer went over 21! Player wins.");
            return true;
        }
        //end dealer's turn
        return true;
    }
}
