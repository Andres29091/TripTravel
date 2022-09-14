namespace NRWeb.Interfaces.Log
{
  public interface ILogService
  {
    void WriteEventLog(String index, String action, String message, String type);
  }
}
