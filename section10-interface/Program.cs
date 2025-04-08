using section10_interface;

CellPhone cp = new CellPhone("abc@aaa.com", "080-1234-5678");

cp.Call("012-333-206");
cp.SendMail("bbb@bbb.com");

// 上記作成した cp インスタンスを IPhone でキャストする
IPhone phone = (IPhone)cp;
phone.Call("012-333-206");
// phone.SendMail("bbb@bbb.com"); // IPhone 内には SendMail は定義されておらずコンパイルエラーとなる

// 上記作成した cp インスタンスを IPhone でキャストする
IEmail mail = (IEmail)cp;
// mail.Call("012-333-206");    // IEmail 内には Call は定義されておらずコンパイルエラーとなる
mail.SendMail("bbb@bbb.com");