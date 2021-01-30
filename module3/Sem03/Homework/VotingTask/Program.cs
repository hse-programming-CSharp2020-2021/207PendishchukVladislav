using System;

namespace VotingTask
{
    class VetoVoter
    {
        public string Name { get; private set; }

        public void VetoVote(object sender, VetoEventArgs e)
        {
            Random rand = new Random();
            if (e.VetoBy != null) return;
            if (rand.Next(0, 5) == 1) e.VetoBy = this;
        }

        public VetoVoter(string name)
        {
            Name = name;
        }
    }

    class VetoComission
    {
        public event EventHandler<VetoEventArgs> OnVote;

        public VetoEventArgs Vote(string Proposal)
        {
            VetoEventArgs vetoVoteArgs = new VetoEventArgs(Proposal);
            OnVote?.Invoke(this, vetoVoteArgs);
            return vetoVoteArgs;
        }
    }

    class VetoEventArgs : EventArgs
    {
        public string Proposal { get; set; }

        public VetoVoter VetoBy { get; set; }

        public VetoEventArgs(string proposal)
        {
            Proposal = proposal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VetoComission vetoCom = new VetoComission();
            VetoVoter[] voters = new VetoVoter[5];
            string[] voterNames = { "John", "Albert", "Giovanni", "Elisa", "Sean"};

            for (int i = 0; i < voters.Length; i++)
            {
                voters[i] = new VetoVoter(voterNames[i]);
                vetoCom.OnVote += voters[i].VetoVote;
            }

            VetoEventArgs voteResults = vetoCom.Vote("Lifting lockdown");

            Console.WriteLine($"Proposal: {voteResults.Proposal}. Vote result: {(voteResults.VetoBy == null ? "Approved" : "Vetoed")}.");
            if (voteResults.VetoBy != null) Console.WriteLine($"Vetoed by: {voteResults.VetoBy.Name}.");
        }
    }
}
