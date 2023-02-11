/* *************************************************************************** #
#                                                                              #
#                                                         :::      ::::::::    #
#    Puissance.cs                                       :+:      :+:    :+:    #
#                                                     +:+ +:+         +:+      #
#    By: mdoquocb <mdoquocb@student.42quebec.com>   +#+  +:+       +#+         #
#                                                 +#+#+#+#+#+   +#+            #
#    Created: 2022/12/29 12:26:02 by mdoquocb          #+#    #+#              #
#    Updated: 2022/12/29 12:26:04 by mdoquocb         ###   ########.fr        #
#                                                                              #
# *************************************************************************** */


namespace Puissance4
{
    class MainPuisance4
    {
        private static int NbrLine = 7;
        private static int NbrRow = 7; 
        private static int Width = 6;
        private static String Joueur1;
        private static String Joueur2;
        private enum EtatCase { Vide, _1_, _2_, _3_, _4_, _5_, _6_, _7_, Joueur1, Joueur2 }
        private static EtatCase[,] Grille = new EtatCase[NbrRow, NbrRow];
        private static EtatCase AQuiLeTour;
        private static int RowChoix = 0;
        private static int LineChoix = 0;
        private static int RowCheck = 0;
        private static int LineCheck = 0;
        private static ConsoleColor DefColor = ConsoleColor.Green;
        private static int count = 0;


        static void PrintSeparateurHor()
        {
            Console.WriteLine(new string('=', Width * NbrRow + NbrRow + 1));
        }
        
        static void PrintSeparateurVer(int newline)
        {
            if (newline == 1)
                Console.WriteLine("|");
            else
                Console.Write("|");
        }

        static void PrintJeton(String Str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write( Str.PadRight(Width - (Width - Str.Length) / 2).PadLeft(Width));
            Console.ForegroundColor = DefColor;

        }
        static void PrintCase(String Str)
        {
            if (string.IsNullOrEmpty(Str))
                Console.Write( new string(' ', Width));
            else
                Console.Write( Str.PadRight(Width - (Width - Str.Length) / 2).PadLeft(Width));
        }

        static void PrintRow(int Line)
        {
            for (int Row = 0; Row < NbrRow; ++Row)
            {
                PrintSeparateurVer(0);
                switch (Grille[Line, Row])
                {
                    case EtatCase.Vide :
                        PrintCase("");
                        break;
                    case EtatCase._1_ :
                        PrintCase("1");
                        break;
                    case EtatCase._2_ :
                        PrintCase("2");
                        break;
                    case EtatCase._3_ :
                        PrintCase("3");
                        break;
                    case EtatCase._4_ :
                        PrintCase("4");
                        break;
                    case EtatCase._5_ :
                        PrintCase("5");
                        break;
                    case EtatCase._6_ :
                        PrintCase("6");
                        break;
                    case EtatCase._7_ :
                        PrintCase("7");
                        break;
                    case EtatCase.Joueur1 :
                        PrintJeton("0", ConsoleColor.Yellow);
                        break;
                    case EtatCase.Joueur2 :
                        PrintJeton("0", ConsoleColor.Red);
                        break;
                }
            }
            PrintSeparateurVer(1);
        }
        
        static void PrintRowtest(int Line)
        {
            for (int Row = 0; Row < NbrRow; ++Row)
            {
                PrintSeparateurVer(0);
                if (Line == LineCheck && RowCheck == Row)
                    PrintCase("X");
                else
                    PrintCase("");
            }
            PrintSeparateurVer(1);
        }
        static void AfficherGrilletest()
        {
            Console.Clear();
            for (int line = 0; line < NbrLine; ++line)
            {
                PrintSeparateurHor();
                PrintRowtest(line);
            }
            PrintSeparateurHor();
            Thread.Sleep(1500);
        }
        
        static void AfficherGrille()
        {
            Console.Clear();
            for (int line = 0; line < NbrLine; ++line)
            {
                PrintSeparateurHor();
                PrintRow(line);
            }
        }

        static bool VerifierPlace(string choixDuJoueur)
        {
            if ( int.TryParse(choixDuJoueur, out RowChoix))
            {
                RowChoix--;
                if (RowChoix < 7 && RowChoix >= 0)
                {
                    for (int line = NbrLine - 1; line >= 1; --line)
                    {
                        if (Grille[line, RowChoix] == EtatCase.Vide)
                        {
                            LineChoix = line;
                            return false;
                        }
                    }
                    Console.WriteLine("essaie avec une autre case");
                    return true;
                }
                Console.WriteLine("essaie avec un chiffre entre 1 - 7");
                return true;
            } 
            Console.WriteLine("essaie avec un chiffre");
            return true;
        }

        static void Checkright(EtatCase etat, int line, int row)
        {
            for ( ; row < NbrRow; ++row)
            {
                RowCheck = row;
                LineCheck = line;
                AfficherGrilletest();
                if (Grille[line, row] != etat)
                    break;
                count++;
            }
        }
        
        static void Checkleft(EtatCase etat, int line, int row)
        {
            for ( ; row >= 0; --row)
            {
                RowCheck = row;
                LineCheck = line;
                AfficherGrilletest();
                if (Grille[line, row] != etat)
                    break;
                count++;
            }
            
        }
        static void Checkdown(EtatCase etat, int line, int row)
        {
            for ( ; line < NbrLine ; ++line)
            {
                RowCheck = row;
                LineCheck = line;
                AfficherGrilletest();
                if (Grille[line, row] != etat)
                    break;
                count++;
            }
        }
        
        static void Checkup(EtatCase etat, int line, int row)
        {
            for ( ; line > 0; --line)
            {
                RowCheck = row;
                LineCheck = line;
                AfficherGrilletest();
                if (Grille[line, row] != etat)
                    break;
                count++;
            }
            
        }
        static void CheckrightUP(EtatCase etat, int line, int row)
        {
            for ( ; row < NbrRow && line >=0 ; ++row, --line)
            {
                RowCheck = row;
                LineCheck = line;
                AfficherGrilletest();
                if (Grille[line, row] != etat)
                    break;
                count++;
            }
        }
        
        static void CheckleftDown(EtatCase etat, int line, int row)
        {
            for ( ; line < NbrLine && row >= 0 ; --row, ++line)
            {
                RowCheck = row;
                LineCheck = line;
                AfficherGrilletest();
                if (Grille[line, row] != etat)
                    break;
                count++;
            }
            
        }
        static void CheckrightDown(EtatCase etat, int line, int row)
        {
            for ( ; row < NbrRow && line < NbrLine ; ++row, ++line)
            {
                RowCheck = row;
                LineCheck = line;
                AfficherGrilletest();
                if (Grille[line, row] != etat)
                    break;
                count++;
            }
        }
        
        static void CheckleftUp(EtatCase etat, int line, int row)
        {
            for ( ; row >= 0 && line >=0 ; --row, --line)
            {
                RowCheck = row;
                LineCheck = line;
                AfficherGrilletest();
                if (Grille[line, row] != etat)
                    break;
                count++;
            }
            
        }

        static bool Checkline()
        {
            Checkright(AQuiLeTour, LineChoix, RowChoix);
            Checkleft(AQuiLeTour, LineChoix, RowChoix  - 1);

            if (count >= 4)
                return true;
            else
                count = 0;
            return false;
        }
        
        static bool CheckRow()
        {
            Checkdown(AQuiLeTour, LineChoix, RowChoix);
            Checkup(AQuiLeTour, LineChoix - 1, RowChoix);
         
            if (count >= 4)
                return true;
            else
                count = 0;
            return false;
        }

        static bool CheckDiag()
        {
            CheckleftDown(AQuiLeTour, LineChoix, RowChoix);
            Console.WriteLine( count);
            CheckrightUP(AQuiLeTour, LineChoix - 1 , RowChoix + 1);
            Console.WriteLine( count);
            if (count >= 4)
                return true;
            else
                count = 0;
            CheckrightDown(AQuiLeTour, LineChoix, RowChoix);
            Console.WriteLine( count);
            CheckleftUp(AQuiLeTour, LineChoix - 1, RowChoix - 1);
            Console.WriteLine( count);
            if (count >= 4)
                return true;
            else
                count = 0;
            return false;
        }
        
        static bool VerifierGagnant()
        {
            if (Checkline() || CheckRow() || CheckDiag())
                return false;
            if ( AQuiLeTour == EtatCase.Joueur1)
                AQuiLeTour = EtatCase.Joueur2;
            else
                AQuiLeTour = EtatCase.Joueur1;
            return true;
        }

        static void WaitPlayer()
        {
            PrintSeparateurHor();
            PrintSeparateurVer(0);
            String Joueur = "";
            switch (AQuiLeTour)
            {
                case EtatCase.Joueur1 :
                    Joueur = Joueur1;
                    break;
                case EtatCase.Joueur2 :
                    Joueur = Joueur2;
                    break;
            }
            PrintCase( Joueur + " c'est a ton tour de jouer choisie 1-7 : ");
            PrintSeparateurVer(1);
            PrintSeparateurHor();
            while (VerifierPlace(Console.ReadLine())) ;
        }
        
        static void WinPlayer()
        {
            PrintSeparateurHor();
            PrintSeparateurVer(0);
            String Joueur = "";
            switch (AQuiLeTour)
            {
                case EtatCase.Joueur1 :
                    Joueur = Joueur1;
                    break;
                case EtatCase.Joueur2 :
                    Joueur = Joueur2;
                    break;
            }
            PrintCase( Joueur + " a gagne!!!    felicitation              ");
            PrintSeparateurVer(1);
            PrintSeparateurHor();
        }
        static void InitGame()
        {
            Console.ForegroundColor = DefColor;
            Random Rnd = new Random();
            
            Console.WriteLine("Nom du joueur 1");
            Joueur1 = Console.ReadLine();
            if (Joueur1.Length < 5)
                Joueur1 = Joueur1.Insert(Joueur1.Length, "     ");
            if (Joueur1.Length > 5)
            {
                Joueur1 = Joueur1.Substring(0, 4);
                Joueur1 = Joueur1.Insert(4, "...");
            }
            Console.WriteLine("Nom du joueur 2");
            Joueur2 = Console.ReadLine();
            if (Joueur2.Length < 5)
                Joueur2 = Joueur2.Insert(Joueur2.Length, "     ");
            if (Joueur2.Length > 5)
            {
                Joueur2 = Joueur2.Substring(0, 4);
                Joueur2 = Joueur2.Insert(4, "...");
            }
            Grille[0,0] = EtatCase._1_;
            Grille[0,1] = EtatCase._2_;
            Grille[0,2] = EtatCase._3_;
            Grille[0,3] = EtatCase._4_;
            Grille[0,4] = EtatCase._5_;
            Grille[0,5] = EtatCase._6_;
            Grille[0,6] = EtatCase._7_;
            for (int i = 1; i < 7; ++i)
            {
                for (int j = 0; j < 7; ++j)
                    Grille[i,j] = EtatCase.Vide;
            }
            if (Rnd.Next() % 2 == 0)
                AQuiLeTour = EtatCase.Joueur1;
            else
                AQuiLeTour = EtatCase.Joueur2;
        }

        static void PrintTitle()
        {
            String Title = "Welcom to Puissance 4";
            foreach (char c in Title)
            {
                Console.Write(c);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            foreach (char c in Title)
            {
                Console.Write("=");
                Thread.Sleep(50);
            }
        }

        static void SetGrill()
        {
            Grille[LineChoix, RowChoix] = AQuiLeTour;
        }
        
        static void Main(string[] args)
        {
            InitGame();
            PrintTitle();
            do{
                AfficherGrille();
                WaitPlayer();
                SetGrill();
            }
            while (VerifierGagnant()) ;
            AfficherGrille();
            WinPlayer();
        }
    }
}

