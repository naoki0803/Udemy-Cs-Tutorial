namespace section10_interface;

// public class CellPhone : IPhone, IEmail
public class CellPhone : IPhone, IEmail
{
    //メールアドレス
    private string _mailAddress;

    // 電話番号
    private string _number;

    // コンストラクタ(メールアドレスと電話番号を設定)
    public CellPhone(string mailAddress, string number)
    {
        this._mailAddress = mailAddress;
        this._number = number;
    }
    // 指定したメールアドレスのメールを送信する
    public void SendMail(string address)
    {
        Console.WriteLine($"{address}に{_mailAddress}へメールを送信します");
    }
    // 指定した番号に電話をかける
    public void Call(string number)
    {
        Console.WriteLine($"{number}に、{_number}から電話をかけます。");
    }
}
