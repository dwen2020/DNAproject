
using System;
using System.Collections.Generic;
using System.Text;

namespace DNAProject
{
    public class Program
    {
        static void Main()
        {
            //You could mainly use unit tests for testing.
        }
    }

    /// <summary>
    /// this class has methods that perform different operations on DNA
    /// </summary>
    public class DNA
    {
        private string dna; //this is the only allowed field for this class

        /// <summary>
        /// this construtor sets the dna field of type string
        /// </summary>
        /// <param name="dna"> the field to be set </param>
        public DNA(string dna)
        {
            this.dna = dna;
            if (!IsValidDNA(dna))
            {
                throw new ArgumentException("Invalid DNA sequence");
            }
        }

        /// <summary>
        /// this method checks if the DNA sequence is a protein
        /// </summary>
        /// <returns> true or false depending on if dna is a protein or not </returns>
        public bool IsProtein()
        {
            string cleanedDna = "";
            foreach (char nuc in dna)
            {
                if (nuc == 'A' || nuc == 'C' || nuc == 'T' || nuc == 'G')
                {
                    cleanedDna += nuc;
                }
            }

            if (cleanedDna.StartsWith("ATG"))
            {
                if (cleanedDna.EndsWith("TAA") || cleanedDna.EndsWith("TAG") || cleanedDna.EndsWith("TGA"))
                {
                    if ((cleanedDna.Length / 3) >= 5)
                    {
                        double cytMass = NucleotideCount('C')* 111.103;
                        double guaMass = NucleotideCount('G') * 151.128;

                        if ((cytMass + guaMass) / TotalMass() >= 0.3)
                        {
                            return true; 
                        }


                    }
                }
            }
            return false;
        }

        /// <summary>
        /// this method calculates the mass of the entire DNA sequence
        /// </summary>
        /// <returns> mass of dna rounded to one decimal place</returns>
        public double TotalMass()
        {
            double ade = 135.128;
            double cyt = 111.103;
            double gua = 151.128;
            double thy = 125.107;
            double junk = 100.000;
            double mass = 0.0;
            foreach (char nuc in dna)
            {
                if (nuc == 'A')
                {
                    mass += ade;
                }
                else if (nuc == 'C')
                {
                    mass += cyt;
                }
                else if (nuc == 'G')
                {
                    mass += gua;
                }
                else if (nuc == 'T')
                {
                    mass += thy;
                }
                else
                {
                    mass += junk;
                }
            }
            return Math.Round(mass, 1);
        }
        /// <summary>
        /// this method counts the number of a specified nucleotide in the DNA
        /// </summary>
        /// <param name="c"> the nucleotide to be counted (A, C, G, T) </param>
        /// <returns> the number of times the chosen nucleotide appears in the dna. Returns 0 for invalid nucleotides </returns>
        public int NucleotideCount(char c)
                {
                    int count = 0;

                    foreach (char nuc in dna)
                    {
                        if (c == nuc)
                        {
                            count++;
                        }
                    }
                    return count;
                }

        /// <summary>
        /// this method creates a hashset with all the different codons in the dna
        /// </summary>
        /// <returns> returns a hashset that contains all the distinct codons in the dna </returns>
        public HashSet<string> CodonSet()
            {
                HashSet<string> set = new HashSet<string>();
                string cleanedDna = "";
                foreach (char nuc in dna)
                {
                    if (nuc == 'A' || nuc == 'C' || nuc == 'T' || nuc == 'G')
                    {
                        cleanedDna += nuc;
                    }
                }

                for (int i=0;i<cleanedDna.Length; i += 3)
                {
                    set.Add(cleanedDna.Substring(i, 3));
                }
                return set;
            }

        /// <summary>
        /// this method mutates the DNA sequence by removing junk regions and replacing all occurences of a specific codon with another codon
        /// returns nothing
        /// </summary>
        /// <param name="originalCodon"> the codon to be replaced in the dna sequence </param>
        /// <param name="newCodon"> the codon that replaces the original codon </param>
        public void MutateCodon(string originalCodon, string newCodon)
        {
             string cleanedDna = "";
            //string cleanedOriginalCodon = "";
            //string cleanedNewCodon = "";
             if (IsValidDNA(originalCodon) && IsValidDNA(newCodon))
             {
                foreach (char nuc in dna)
                {
                    if (nuc == 'A' || nuc == 'C' || nuc == 'T' || nuc == 'G')
                    {
                        cleanedDna += nuc;
                    }
                }

                dna = cleanedDna;
               
                dna = dna.Replace(originalCodon, newCodon);
             }
         }

        /// <summary>
        /// this method gets the nucleotide sequence
        /// </summary>
        /// <returns> returns the dna sequence as a string </returns>
        public string GetSequence()
        {
                return dna;
        }

        /// <summary>
        /// this method checks if the  DNA sequence is valid based on codons
        /// </summary>
        /// <param name="dnaSequence"> the DNA Sequence to be checked for validity </param>
        /// <returns> returns true or false based on if dnaSequence is valid or not </returns>
        public bool IsValidDNA(string dnaSequence)
        {
                int count = 0;
                foreach(char c in dnaSequence)
                {
                    if (c=='A'|| c == 'C' || c == 'T'|| c == 'G')
                    {
                        count++;
                    }
                }

                if (count % 3 == 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }
                
         
        }
    }
}