namespace csharp
{
    public interface Item
    {
        string getName();
        int getSellin();
        int getQuality();
        void setName(string name);
        void setQuality(int quality);
        void setSellin(int sellIn);
        string ToString();
        void UpdateQuality();
    }
}
