namespace ConsoleApp1
{
    public class Digit
    {
        public int FaceValue { get; set; }

        public int Place { get; set; }

        public int PlaceValue => FaceValue * Place;
    }
}
