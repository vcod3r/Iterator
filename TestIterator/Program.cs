using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIterator
{
    internal class Program
    {
        internal struct ElementA
        {
            public double Position { get; set; }
            public double Value1 { get; set; }
            public double Value2 { get; set; }
        }

        internal struct ElementB
        {
            public double Position { get; set; }
            public double Value3 { get; set; }
            public double Value4 { get; set; }
        }

        internal struct Pair
        {
            public double First { get; set; }
            public double Second { get; set; }
        }

        internal enum ValueSource
        {
            Field1,
            Field2,
            Field3,
            Field4
        }

        internal class C
        {
            public List<ElementA> vecElementA { get; set; }
            public List<ElementB> vecElementB { get; set; }

            /// <summary>
            /// Creates a full collection of pairs
            /// </summary>
            /// <param name="source"></param>
            /// <returns></returns>
            public IEnumerable<Pair> MakePairsCollection(ValueSource source)
            {
                switch (source)
                {
                    case ValueSource.Field1:
                        return vecElementA.Select(e => new Pair { First = e.Position, Second = e.Value1 });

                    case ValueSource.Field2:
                        return vecElementA.Select(e => new Pair { First = e.Position, Second = e.Value2 });

                    case ValueSource.Field3:
                        return vecElementB.Select(e => new Pair { First = e.Position, Second = e.Value3 });

                    case ValueSource.Field4:
                        return vecElementB.Select(e => new Pair { First = e.Position, Second = e.Value4 });

                    default:
                        return new List<Pair>();
                }
            }

            /// <summary>
            /// Creates an iterator that yields the pairs
            /// </summary>
            /// <param name="source"></param>
            /// <returns></returns>
            public IEnumerable<Pair> MakePairsYield(ValueSource source)
            {
                switch (source)
                {
                    case ValueSource.Field1:
                        {
                            foreach (var e in vecElementA)
                            {
                                yield return new Pair { First = e.Position, Second = e.Value1 };
                            }
                            break;
                        }

                    case ValueSource.Field2:
                        {
                            foreach (var e in vecElementA)
                            {
                                yield return new Pair { First = e.Position, Second = e.Value2 };
                            }
                            break;
                        }

                    case ValueSource.Field3:
                        {
                            foreach (var e in vecElementB)
                            {
                                yield return new Pair { First = e.Position, Second = e.Value3 };
                            }
                            break;
                        }

                    case ValueSource.Field4:
                        {
                            foreach (var e in vecElementB)
                            {
                                yield return new Pair { First = e.Position, Second = e.Value4 };
                            }
                            break;
                        }

                    default:
                        yield break;
                }
            }
        }

        static void Main(string[] args)
        {
            C c = new C();

            c.vecElementA = new List<ElementA>
                {
                    new ElementA { Position = 0, Value1 = 10, Value2 = 20 },
                    new ElementA { Position = 1, Value1 = 11, Value2 = 21 },
                    new ElementA { Position = 2, Value1 = 12, Value2 = 22 },
                    new ElementA { Position = 3, Value1 = 13, Value2 = 23 },
                    new ElementA { Position = 4, Value1 = 14, Value2 = 24 },
                    new ElementA { Position = 5, Value1 = 15, Value2 = 25 },
                    new ElementA { Position = 6, Value1 = 16, Value2 = 26 },
                    new ElementA { Position = 7, Value1 = 17, Value2 = 27 },
                    new ElementA { Position = 8, Value1 = 18, Value2 = 28 },
                    new ElementA { Position = 9, Value1 = 19, Value2 = 29 }
                };

            c.vecElementB = new List<ElementB>
                {
                    new ElementB { Position = 0, Value3 = 30, Value4 = 40 },
                    new ElementB { Position = 1, Value3 = 31, Value4 = 41 },
                    new ElementB { Position = 2, Value3 = 32, Value4 = 42 },
                    new ElementB { Position = 3, Value3 = 33, Value4 = 43 },
                    new ElementB { Position = 4, Value3 = 34, Value4 = 44 },
                    new ElementB { Position = 5, Value3 = 35, Value4 = 45 },
                    new ElementB { Position = 6, Value3 = 36, Value4 = 46 },
                    new ElementB { Position = 7, Value3 = 37, Value4 = 47 },
                    new ElementB { Position = 8, Value3 = 38, Value4 = 48 },
                    new ElementB { Position = 9, Value3 = 39, Value4 = 49 }
                };

            // Iterate over returned collection
            foreach (var pair in c.MakePairsCollection(ValueSource.Field4))
            {
                Console.WriteLine(pair.First + "," + pair.Second);
            }

            // Iterate using yield
            foreach (var pair in c.MakePairsYield(ValueSource.Field4))
            {
                Console.WriteLine(pair.First + "," + pair.Second);
            }
        }
    }
}
