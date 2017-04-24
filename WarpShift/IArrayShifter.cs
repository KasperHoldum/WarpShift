namespace WarpShift
{
    public interface IMapShifter
    {
        void Shift(ShiftCommand cmd, StringMap map);
    }
}
