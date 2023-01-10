namespace DNAProject.Tests
{
    [TestClass()]
    public class DNATests
    {
        [TestMethod()]
        public void Test1_TotalMass()
        {
            DNA dna1 = new DNA("ATGCCAxCTATGGTAG");
            Assert.AreEqual(2078.8, dna1.TotalMass(), 0.001);
        }

        [TestMethod()]
        public void Test2_IsProtein()
        {
            DNA dna2 = new DNA("ATGCCAACATGGATGCCCGATAT++GGATTG+A!");
            Assert.IsTrue(dna2.IsProtein());
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test3_Constructor_InvalidSeq()
        {
            DNA dna3 = new DNA("-TA");
        }

        [TestMethod()]
        public void Test4_NucleotideCount()
        {
            DNA dna4 = new DNA("AAAGGTTACTGA");
            Assert.AreEqual(5, dna4.NucleotideCount('A'));
        }

        [TestMethod()]
        public void Test5_CodonSet()
        {
            DNA dna5 = new DNA("AAAGGTTACTGA");
            HashSet<string> expectedSet = new HashSet<string>();
            expectedSet.Add("AAA");
            expectedSet.Add("GGT");
            expectedSet.Add("TAC");
            expectedSet.Add("TGA");
            Assert.IsTrue(expectedSet.SetEquals(dna5.CodonSet()));
        }

        [TestMethod()]
        public void Test6_GetSequence()
        {
            DNA dna6 = new DNA("AAAGGTTACTGA");
            Assert.AreEqual("AAAGGTTACTGA", dna6.GetSequence());
        }

        [TestMethod()]
        public void Test7_MutateCodon()
        {
            DNA dna7 = new DNA("AAAGGTTACTG+A");
            dna7.MutateCodon("TGA", "GAT");
            Assert.AreEqual("AAAGGTTACGAT", dna7.GetSequence());
        }

        [TestMethod()]
        public void Test8_MutateCodon2()
        {
            DNA dna7 = new DNA("AAAGGTTACTG+A");
            dna7.MutateCodon("TGA", "G+T");
            Assert.AreEqual("AAAGGTTACTG+A", dna7.GetSequence());
        }

        [TestMethod()]
        public void Test9()
        {
            DNA dna8 = new DNA("ATGCCAxCTATGGTAG");
            dna8.MutateCodon("CTA", "ATC");
            Assert.AreEqual(1978.8, dna8.TotalMass(), 0.001);
        }
        [TestMethod()]
        public void Test10()
        {
            DNA dna8 = new DNA("ATGCCAxCTATGGTAG");
            dna8.MutateCodon("CTA", "ATC");
            Assert.AreEqual("ATGCCAATCTGGTAG", dna8.GetSequence());
        }
    }
}