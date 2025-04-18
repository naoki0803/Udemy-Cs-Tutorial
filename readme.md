## プロジェクトの作成方法

### 基本的な作成方法

```
 dotnet new console -n Sample101
```

new 第二引数にどのようなアプリケーションを作成するかを記述する

### 古いバージョンで作成する方法

```
$ dotnet new console --use-program-main -n Sample101-OldStyle
```

`--use-program-main`を付ける事で、Program.cs で作成されたアプリが、
古いバージョンの記述になる。

#### --use-program-main 無し(新しいバージョン)

```Sample101/Program.cs
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

#### --use-program-main 有り(古いバージョン)

```Sample101-OldStyle/Program.cs
namespace Sample101_OldStyle;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("HelloWorld.");
        // Console.WriteLine("Hello, World!");
    }
}
```

### help の確認

```

$ dotnet new --help

```

確認したい引数や、オプションの後ろで `--help` を記述する

## ソリューションファイル(.sln)

ワークフォルダ内に複数のプロジェクトを作成しており、全体を 1 つのプロジェクトとして管理したい場合、
root 直下にある、ソリューションファイルにソリューションを追加する必要がある。

```zsh
$ dotnet sln <ソリューション名>.sln add <プロジェクトパス>/<プロジェクト名>.csproj
```

## コメントアウト

javascript と同じく // でコメントアウト

## 文字列の扱いについて

ダブルクオーテーションで記述する必要有り

OK `Console.WriteLine("HelloWorld.");`
NG `Console.WriteLine('HelloWorld.');` // : error CS1012: 文字リテラルに文字が多すぎます

## エディタでの実行方法

### 単発で実行する場合

```
$ dotnet run
```

### 保存時に自動的に実行する(nodemon のような)

```
$ dotnet watch run
```

## Console.WriteLine の利用方法

### 基本的な利用方法

```
Console.WriteLine("改行して");
Console.WriteLine("結果を出力");
// 改行して
// 結果を出力

Console.Write("改行なし");
Console.Write("で出力");
// 改行なしで出力
```

### 文字列補完 (javascript でいうテンプレートリテラル)

```
string firstName = "鈴木";
string lastName = "太郎";
Console.WriteLine($"私は、{firstName}{lastName}です");
// 私は鈴木たろうです

```

## 変数宣言

変数宣言は `type 変数名 = 値;` と記述をする
※ 同一 type であれば複数の変数も宣言可能
`type 変数名1 = 値, 変数名2 = 値, 変数名3 = 値;`

type の種類一例

-   int 整数型
-   double 小数点
-   string 文字型

```
int number;
int numberVal = 777;
double doubleNumber = 777.777;
string name = "Suzuki Taro"

同一typeであれば複数変数を宣言可能

string firstName="鈴木", lastName="太郎";
```

## ユーザーの入力の取得

Console.ReadLine();を利用する事で、実行時は該当行で処理が一次停止し、
ユーザーの入力が完了(Enter 押下)されると、処理が進むようになる。

戻り値として、ユーザーの入力した値が`文字列`として取得できる

```cs
string? inputValue1, inputValue2;
Console.Write("苗字を入力してください => ");
inputValue1 = Console.ReadLine();
Console.Write("名字を入力してください => ");
inputValue2 = Console.ReadLine();
Console.WriteLine($"あなたの名前は{inputValue1} {inputValue2}:です");
```

## if 文

基本構文は JavaScript と変わらない

ただし、cs は静的型付け言語なので、等価演算子は `===` ではなく、`==` を利用する
また、truthy / falsy という概念は cs にはなく、空文字や null の判定は明示的なメソッド呼び出しが必要
※API 連携時には null と undefined の扱いを明確にする必要がある。

**空文字の扱い** ""は false String.IsNullOrEmpty()で判定
**null/undefined** 両者とも false null のみ存在（undefined はなし）
**コレクションの扱い** 空配列[]は true 空コレクションは null でないがコンテナ自体のチェックが必要

```
csharp
// 空文字チェック
if (String.IsNullOrEmpty(text)) { /* 処理 */ }

// nullチェック（オブジェクトの場合）
if (obj == null) { /* 処理 */ }

// JSONデシリアライズ時のnull扱い
// Newtonsoft.Jsonの場合、nullはundefinedとして扱われない
// 必要な場合はNullValueHandling.Ignoreでプロパティを省略可能[7]
```

## switch 文

基本的な記述方法は JavaScript と同じ
※注意点として、フォールスルーの処理は構文エラーになる

```
int num = int.Parse(Console.ReadLine());
switch (num) {
    case 1:
    case 9: // caseを2つ指定することも可能
        Console.WriteLine("1 or 9 です");
        break;
    case 2:
        Console.WriteLine("2 です");
        break;
    case 3:
        Console.WriteLine("3 です");
        break;
    default:
        Console.WriteLine("1から3 もしくは 9 の整数を入力してください。");
        break;
}
```

## 配列

### 基本的な配列

#### 配列の定義と代入を同時に行う方法

JavaScript とは異なり、`波括弧`で配列を記述する。

```cs
int[] numbers = { 1, 3, 4, 10 };
double[] doubleArr = { 1.2, 3.7, 4.1 };
string[] strings = { "ABC", "DEF", "GHI" };
// 型[] 変数名 = new 型[要素数];
// 型[0] = 代入値1;
// 型[1] = 代入値2;
```

#### 初期化と代入を別で行う方法

初期化の際は`角括弧`で記述して、配列の要素数を指定する必要がある。

```cs
double[] arr = new double[3];
arr[0] = 1.2;
arr[1] = 3.7;
arr[2] = 4.1;
```

### ジャグ配列

ジャグ配列は二次元配列の内部で定義した配列の長さが、各配列で異なる配列

```cs
{ {1}、 {2,2}、 {3,3,3} }
```

#### 定義方法

それぞれの配列を、new 演算子で作成をする

```cs
int[] matrixJagArr = { new int[]{1}, new int[] {2,2}, new int[] {3,3,3} }
```

## namespace

namespace が異なるファイルを利用する場合、呼び出し元の上部に`using`を記述することで、別の namespace のファイルを参照する事が可能になる。

```cs
using namespace名;
```

### トップレベルステートメント

TODO: ざっくりは理解できたけど、他ファイルの読み込み等を含めると概念がいまだ理解できていない。
[トップレベルステートメントのチュートリアル](https://learn.microsoft.com/ja-jp/dotnet/csharp/tutorials/top-level-statements)

小規模なアプリケーションに向いている

## Class

### class の定義と構造

C#のクラスは、オブジェクト指向プログラミングの基本単位です。データ（フィールド、プロパティ）とその操作（メソッド）を一つのユニットにまとめます。

```cs
public class ClassName
{
    // 以下class定義の順番(Microsoftの推奨スタイル)
    // 1. 定数
    // 2. フィールド（private/protected）
    // 3. コンストラクタ
    // 4. プロパティ
    // 5. メソッド
    // 6. 内部クラス/enum
}
```

### 1. 定数とフィールド

**定数**：値が変更されない静的な値です。

```cs
public class Person
{
    // 定数（大文字のスネークケースが慣習）
    public const int MAX_AGE = 120;
    public const string DEFAULT_COUNTRY = "Japan";

    // フィールド（先頭に_をつけるのが一般的な命名規則）
    private string _name;
    private int _age;
    private readonly DateTime _birthDate; // readonlyは初期化後に変更不可
}
```

フィールドは内部的に保持する値で、基本的には `private` または `protected` を設定してカプセル化します。外部からの参照や編集はプロパティを通してコントロールします。

### 2. コンストラクタ

コンストラクタはインスタンス生成時に 1 回だけ実行される特殊なメソッドです。初期化処理を行います。

```cs
public class Person
{
    private string _name;
    private int _age;
    private readonly DateTime _birthDate;

    // デフォルトコンストラクタ
    public Person()
    {
        _name = "名無し";
        _age = 0;
        _birthDate = DateTime.Now;
    }

    // パラメータ付きコンストラクタ
    public Person(string name, int age, DateTime birthDate)
    {
        _name = name;
        _age = age;
        _birthDate = birthDate;
    }

    // コンストラクタのオーバーロード
    public Person(string name) : this(name, 0, DateTime.Now)
    {
        // thisキーワードで他のコンストラクタを呼び出せる
    }
}
```

### 3. プロパティ

プロパティはフィールドへのアクセスを制御するための機能です。`get`と`set`アクセサーを使って、読み取りや書き込みの制御が可能です。

#### 完全なプロパティ（バッキングフィールドあり）

```cs
public class Person
{
    private string _name;
    private int _age;

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("名前を入力してください");
            _name = value;
        }
    }

    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0 || value > MAX_AGE)
                throw new ArgumentOutOfRangeException("年齢は0～120の間で設定してください");
            _age = value;
        }
    }
}
```

#### 自動実装プロパティ（簡潔な記述）

```cs
public class Person
{
    // 自動実装プロパティ（コンパイラが自動的にバッキングフィールドを生成）
    public string Name { get; set; }              // 完全な読み書きアクセス
    public int Age { get; private set; }          // 外部からは読み取り専用
    public DateTime BirthDate { get; init; }      // C# 9.0以降: 初期化時のみ設定可能
    public string FullName => $"{Name} {LastName}"; // 式形式のプロパティ（読み取り専用）
}
```

### 4. メソッド

メソッドはクラスの振る舞いを定義する関数です。

```cs
public class Person
{
    private string _name;
    private int _age;

    // インスタンスメソッド
    public void Introduce()
    {
        Console.WriteLine($"こんにちは、{_name}です。{_age}歳です。");
    }

    // パラメータと戻り値のあるメソッド
    public bool CanVote(string country)
    {
        return country == "Japan" ? _age >= 18 : _age >= 16;
    }

    // 静的メソッド（クラスに属するメソッド）
    public static Person CreateAdult(string name)
    {
        return new Person(name, 20);
    }

    // オーバーロードメソッド（同じ名前で異なるパラメータ）
    public void UpdateInfo(string name)
    {
        _name = name;
    }

    public void UpdateInfo(int age)
    {
        _age = age;
    }

    public void UpdateInfo(string name, int age)
    {
        _name = name;
        _age = age;
    }
}
```

### 5. 内部クラス/enum

クラス内部に別のクラスや enum 型を定義することもできます。

```cs
public class Person
{
    // 内部enum
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    // フィールド
    private string _name;
    private int _age;
    private Gender _gender;
    private Address _address;

    // プロパティ
    public Gender CurrentGender { get; set; }

    // 内部クラス
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return $"{PostalCode} {City} {Street}";
        }
    }

    // 内部クラスを使用するメソッド
    public void SetAddress(string street, string city, string postalCode)
    {
        _address = new Address
        {
            Street = street,
            City = city,
            PostalCode = postalCode
        };
    }
}
```

### 継承とインターフェース

クラスは他のクラスを継承したり、インターフェースを実装したりできます。

```cs
// インターフェース
public interface IMovable
{
    void Move(int x, int y);
    double Speed { get; }
}

// 基底クラス
public class Human
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void Speak()
    {
        Console.WriteLine("人間が話します");
    }
}

// 派生クラス（継承とインターフェース実装）
public class Student : Human, IMovable
{
    public string StudentId { get; set; }
    public double GPA { get; set; }

    // コンストラクタ
    public Student(string name, int age, string studentId)
    {
        Name = name;
        Age = age;
        StudentId = studentId;
    }

    // オーバーライドメソッド
    public override void Speak()
    {
        Console.WriteLine($"学生の{Name}が話します");
    }

    // インターフェースの実装
    public void Move(int x, int y)
    {
        Console.WriteLine($"学生が({x},{y})に移動しました");
    }

    public double Speed => 5.0; // インターフェースのプロパティ実装
}
```

### アクセス修飾子

C#では以下のアクセス修飾子を使用できます：

-   `public`: どこからでもアクセス可能
-   `private`: 同じクラス内からのみアクセス可能
-   `protected`: 同じクラスおよび派生クラスからアクセス可能
-   `internal`: 同じアセンブリ（プロジェクト）内からアクセス可能
-   `protected internal`: 同じアセンブリ内または派生クラスからアクセス可能
-   `private protected`: 同じアセンブリ内の派生クラスからのみアクセス可能

```cs
public class AccessExample
{
    public int PublicField;
    private int _privateField;
    protected int ProtectedField;
    internal int InternalField;
    protected internal int ProtectedInternalField;
    private protected int PrivateProtectedField;
}
```

## 継承

### 継承とは？

継承（Inheritance）は、オブジェクト指向プログラミングの重要な概念の一つで、既存のクラス（親クラス・基底クラス）の特性や機能を引き継いで、新しいクラス（子クラス・派生クラス）を作成する仕組みです。

継承を使うと以下のようなメリットがあります：

-   **コードの再利用**: 既存のクラスの機能を再利用できるため、重複コードを減らせます
-   **拡張性**: 既存の機能を保ちながら、新しい機能を追加できます
-   **階層構造**: 類似したクラス間の関係を明確な階層で表現できます

### 継承の基本的な記述方法

C#では、継承する子クラスを定義する際に、クラス名の後にコロン（:）を付け、その後に親クラスの名前を記述します。

```cs
public class 子クラス名 : 親クラス名
{
    // 子クラスの内容
}
```

### 継承の実践例

以下は計算機能を持つクラスの継承の例です：

```cs:ParentCalc.cs
public class ParentCalc
{
    // protectedアクセス修飾子を使うと、このクラスと派生クラスからアクセス可能
    protected int num1;
    protected int num2;

    // コンストラクタ
    public ParentCalc(int num1, int num2)
    {
        this.num1 = num1;
        this.num2 = num2;
    }

    // プロパティ
    public int Num1 { set; get; }
    public int Num2 { set; get; }

    // メソッド
    public int Add()
    {
        return num1 + num2;
    }

    public int Sub()
    {
        return num1 - num2;
    }
}
```

```cs:ChildCalc.cs
public class ChildCalc : ParentCalc
{
    // 子クラスのコンストラクタ
    // base(num1, num2)で親クラスのコンストラクタを呼び出す
    public ChildCalc(int num1, int num2) : base(num1, num2)
    {
        // 追加の初期化処理が必要な場合はここに記述
    }

    // 子クラス独自のメソッド（親クラスの機能を拡張）
    public int Mul()
    {
        return num1 * num2;
    }

    public int Div()
    {
        // 実際のコードでは0除算チェックを追加すべき
        return num1 / num2;
    }
}
```

### 継承クラスの使い方

```cs:Program.cs
// 親クラスのインスタンス生成
ParentCalc parentCalc = new ParentCalc(10, 20);

// 子クラスのインスタンス生成
ChildCalc childCalc = new ChildCalc(30, 20);

// 親クラスのメソッド呼び出し
Console.WriteLine($"親クラスAdd:{parentCalc.Add()}"); // 結果: 30
Console.WriteLine($"親クラスSub:{parentCalc.Sub()}"); // 結果: -10

// 子クラスからは親クラスのメソッドも呼び出せる
Console.WriteLine($"子クラスAdd:{childCalc.Add()}"); // 結果: 50
Console.WriteLine($"子クラスSub:{childCalc.Sub()}"); // 結果: 10

// 子クラス独自のメソッド呼び出し
Console.WriteLine($"子クラスMul:{childCalc.Mul()}"); // 結果: 600
Console.WriteLine($"子クラスDiv:{childCalc.Div()}"); // 結果: 1
```

### 継承使用時の重要ポイント

1. **アクセス修飾子の理解**：

    - `private`: 同一クラス内からのみアクセス可能（子クラスからもアクセス不可）
    - `protected`: 同一クラスと派生クラスからアクセス可能
    - `public`: どこからでもアクセス可能

2. **base キーワード**：

    - 子クラスから親クラスのメンバーにアクセスする時に使用
    - コンストラクタでは`: base(引数)`の形で親クラスのコンストラクタを呼び出す

3. **メソッドのオーバーライド**：
    - 親クラスで`virtual`キーワードを使用したメソッドを
    - 子クラスで`override`キーワードを使用して再定義できる

### 実際の使用例

計算機の例以外にも、継承は多くの場面で活用できます：

-   `Person`クラスを継承した`Student`、`Teacher`クラス
-   `Animal`クラスを継承した`Dog`、`Cat`、`Bird`クラス
-   `Vehicle`クラスを継承した`Car`、`Motorcycle`、`Bicycle`クラス

継承を使うことで、共通の特性と振る舞いを基底クラスに定義し、個別の特性を派生クラスに追加することで、効率的なコード管理が可能になります。

## 抽象クラス

抽象クラス（Abstract Class）は、C#のオブジェクト指向プログラミングにおける重要な概念です。これは具体的なインスタンスを作成できないクラスで、派生クラスに対する「設計図」として機能します。

### 抽象クラスとは

抽象クラスには以下のような特徴があります：

1. `abstract`キーワードを使用して定義されます
2. 直接インスタンス化することができません
3. 通常のメソッドと抽象メソッド（実装のない宣言だけのメソッド）を含むことができます
4. 派生クラスに特定のメソッドやプロパティの実装を強制することができます

### 抽象クラスの基本的な記述方法

```cs
// abstractキーワードを使ってクラスを定義
public abstract class 抽象クラス名
{
    // 通常のフィールド・プロパティ・メソッド
    public string Name { get; set; }

    // 抽象プロパティ（実装なし、派生クラスでの実装が必須）
    public abstract int AbstractProperty { get; set; }

    // 仮想プロパティ（実装あり、派生クラスでのオーバーライドは任意）
    public virtual string VirtualProperty { get; set; } = "初期値";

    // 通常のメソッド（実装あり）
    public void NormalMethod()
    {
        Console.WriteLine("通常のメソッドです");
    }

    // 抽象メソッド（実装なし、派生クラスでの実装が必須）
    public abstract void AbstractMethod();

    // 仮想メソッド（実装あり、派生クラスでのオーバーライドは任意）
    public virtual void VirtualMethod()
    {
        Console.WriteLine("オーバーライド可能なメソッドです");
    }
}
```

### 抽象プロパティについて

抽象プロパティは抽象メソッドと同様に、派生クラスでの実装が必須のプロパティです。以下のような特徴があります：

1. **実装の強制**：

    - `abstract`キーワードを使って宣言され、派生クラスで必ず実装する必要があります。

2. **アクセサの柔軟性**：

    - 読み取り専用（get のみ）、書き込み専用（set のみ）、または両方のアクセサを宣言できます。
    - 派生クラスでも同じアクセサを実装する必要があります。

3. **記述方法**：

    ```cs
    // 読み書き両方の抽象プロパティ
    public abstract int Property1 { get; set; }

    // 読み取り専用の抽象プロパティ
    public abstract string Property2 { get; }

    // 書き込み専用の抽象プロパティ（あまり一般的ではない）
    public abstract double Property3 { set; }
    ```

### 抽象クラスの実践例

動物を表す抽象クラスと、それを継承した具体的な動物クラスの例です。

```cs:Animal.cs
// 動物を表す抽象クラス
public abstract class Animal
{
    // 通常のプロパティ
    public string Name { get; set; }
    public int Age { get; set; }

    // 抽象プロパティ（派生クラスでの実装が必須）
    public abstract string Species { get; }
    public abstract double Weight { get; set; }

    // コンストラクタ
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // 通常のメソッド
    public void ShowInfo()
    {
        Console.WriteLine($"名前: {Name}, 年齢: {Age}歳, 種類: {Species}, 体重: {Weight}kg");
    }

    // 抽象メソッド（派生クラスでの実装が必須）
    public abstract void MakeSound();

    // 仮想メソッド（派生クラスでのオーバーライドは任意）
    public virtual void Move()
    {
        Console.WriteLine($"{Name}が移動します");
    }
}
```

```cs:Dog.cs
// 動物を継承した具体的な犬クラス
public class Dog : Animal
{
    // 犬特有のプロパティ
    public string Breed { get; set; }

    // 抽象プロパティの実装
    public override string Species => "犬";

    private double _weight;
    public override double Weight
    {
        get { return _weight; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("体重は0より大きい値を設定してください");
            _weight = value;
        }
    }

    // 親クラスのコンストラクタを呼び出す
    public Dog(string name, int age, string breed, double weight) : base(name, age)
    {
        Breed = breed;
        Weight = weight;
    }

    // 抽象メソッドの実装（必須）
    public override void MakeSound()
    {
        Console.WriteLine("ワンワン！");
    }

    // 仮想メソッドのオーバーライド（任意）
    public override void Move()
    {
        Console.WriteLine($"{Name}が走って移動します");
    }

    // 犬クラス独自のメソッド
    public void Fetch()
    {
        Console.WriteLine($"{Name}がボールを取ってきました");
    }
}
```

```cs:Cat.cs
// 動物を継承した具体的な猫クラス
public class Cat : Animal
{
    // 猫特有のプロパティ
    public bool IsIndoor { get; set; }

    // 抽象プロパティの実装
    public override string Species => "猫";

    private double _weight;
    public override double Weight
    {
        get { return _weight; }
        set { _weight = value > 0 ? value : 0.1; }
    }

    // 親クラスのコンストラクタを呼び出す
    public Cat(string name, int age, bool isIndoor, double weight) : base(name, age)
    {
        IsIndoor = isIndoor;
        Weight = weight;
    }

    // 抽象メソッドの実装（必須）
    public override void MakeSound()
    {
        Console.WriteLine("ニャー！");
    }

    // 猫クラス独自のメソッド
    public void Climb()
    {
        Console.WriteLine($"{Name}が木に登ります");
    }
}
```

### 抽象クラスの使い方

```cs:Program.cs
class Program
{
    static void Main(string[] args)
    {
        // 抽象クラスは直接インスタンス化できない
        // Animal animal = new Animal("名前", 1); // コンパイルエラー

        // 派生クラスはインスタンス化できる
        Dog dog = new Dog("ポチ", 3, "柴犬", 12.5);
        Cat cat = new Cat("タマ", 2, true, 4.8);

        // 基本的な情報表示（抽象クラスの通常メソッド）
        dog.ShowInfo();  // 名前: ポチ, 年齢: 3歳, 種類: 犬, 体重: 12.5kg
        cat.ShowInfo();  // 名前: タマ, 年齢: 2歳, 種類: 猫, 体重: 4.8kg

        // 抽象プロパティへのアクセス
        Console.WriteLine($"{dog.Name}の種類: {dog.Species}");  // ポチの種類: 犬
        Console.WriteLine($"{cat.Name}の体重: {cat.Weight}kg"); // タマの体重: 4.8kg

        // 抽象メソッドの実装呼び出し
        dog.MakeSound(); // ワンワン！
        cat.MakeSound(); // ニャー！

        // 仮想メソッドの呼び出し
        dog.Move(); // ポチが走って移動します（オーバーライドされたメソッド）
        cat.Move(); // タマが移動します（親クラスのデフォルト実装）

        // 派生クラス独自のメソッド
        dog.Fetch(); // ポチがボールを取ってきました
        cat.Climb(); // タマが木に登ります

        // 抽象クラス型の変数に派生クラスのインスタンスを代入（ポリモーフィズム）
        Animal animal1 = dog;
        Animal animal2 = cat;

        // 抽象クラス型の変数からでも、オーバーライドされたメソッドとプロパティは正しく呼び出される
        Console.WriteLine($"動物1の種類: {animal1.Species}"); // 動物1の種類: 犬
        Console.WriteLine($"動物2の種類: {animal2.Species}"); // 動物2の種類: 猫
        animal1.MakeSound(); // ワンワン！
        animal2.MakeSound(); // ニャー！
    }
}
```

### 抽象クラスの使用時の重要ポイント

1. **インスタンス化できない**：

    - 抽象クラスは直接インスタンス化できません。必ず継承して使います。

2. **抽象メソッドと実装**：

    - 抽象メソッド（`abstract`）は実装を持たず、派生クラスでの実装が必須です。
    - 仮想メソッド（`virtual`）は実装を持ち、派生クラスでのオーバーライドは任意です。

3. **コンストラクタの役割**：

    - 抽象クラスもコンストラクタを持てますが、それは派生クラスのインスタンス化時に呼び出されます。

4. **抽象クラスと継承**：
    - C#ではクラスは単一継承なので、1 つのクラスは 1 つの抽象クラスしか継承できません。

### 抽象クラスの活用シーン

抽象クラスは以下のような場面で特に有用です：

1. **共通の基本機能を提供する場合**：

    - 複数のクラスで共有される実装を持つメソッドを定義できます。

2. **クラス階層の設計**：

    - オブジェクト指向設計で「is-a」関係を表現するのに最適です。

3. **実装を強制したい場合**：

    - 派生クラスに特定のメソッドの実装を強制できます。

4. **API 設計**：
    - フレームワークやライブラリの設計で、拡張ポイントを提供する際に活用されます。

### 抽象クラスとインターフェイスの違い

抽象クラスとインターフェイスは似ていますが、以下のような違いがあります：

1. **実装の有無**：

    - 抽象クラス：通常のメソッドとフィールド（実装あり）と抽象メソッド（実装なし）の両方を持てる
    - インターフェイス：基本的にメソッドやプロパティの宣言のみ（C# 8.0 以降ではデフォルト実装も可能）

2. **継承の制限**：

    - 抽象クラス：1 つのクラスは 1 つの抽象クラスしか継承できない（単一継承）
    - インターフェイス：1 つのクラスは複数のインターフェイスを実装できる

3. **コンストラクタと状態**：

    - 抽象クラス：コンストラクタと状態（フィールド）を持てる
    - インターフェイス：コンストラクタを持てず、状態も持てない（C# 8.0 以降の静的フィールドを除く）

4. **アクセス修飾子**：
    - 抽象クラス：メンバーに様々なアクセス修飾子を使用できる
    - インターフェイス：メンバーは基本的に public（C# 8.0 以降では一部例外あり）

### 注意点

1. 抽象クラスは継承の階層を作るので、設計をよく考えてから使用しましょう。不適切な抽象化は、将来的なコード変更を難しくする可能性があります。

2. 抽象クラスと派生クラス間の関係は「is-a」関係を表現するべきです。「Dog は（is-a）Animal」のような関係です。

3. 継承よりもコンポジション（構成）の方が適している場合もあります。継承が本当に必要か、常に検討しましょう。

4. 抽象クラスのメンバーを保護するために、適切なアクセス修飾子（`protected`など）を使用しましょう。

## コレクション

コレクションとは、複数のデータをまとめて管理するためのデータ構造です。C#では様々な種類のコレクションが提供されており、用途に応じて使い分けることができます。

### 1. 配列（Array）

配列は最も基本的なコレクションで、同じ型の要素を固定サイズで格納します。

#### 基本的な配列の宣言と初期化

```cs
// 宣言と初期化を同時に行う方法
int[] numbers = { 1, 3, 4, 10 };
double[] doubleArr = { 1.2, 3.7, 4.1 };
string[] strings = { "ABC", "DEF", "GHI" };

// 初期化と代入を別で行う方法
double[] arr = new double[3]; // サイズ3の配列を作成
arr[0] = 1.2;
arr[1] = 3.7;
arr[2] = 4.1;
```

#### 多次元配列とジャグ配列

```cs
// 2次元配列
int[,] matrix = new int[3, 3] {
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};

// ジャグ配列（配列の配列、各配列のサイズが異なる）
int[][] jaggedArray = new int[][] {
    new int[] { 1 },
    new int[] { 2, 2 },
    new int[] { 3, 3, 3 }
};
```

#### 配列の特徴と使用場面

-   **長所**: アクセスが高速、メモリ効率が良い
-   **短所**: サイズが固定（変更不可）
-   **使用場面**: サイズが変わらないデータの集合（例：曜日名、月名）

### 2. リスト（List<T>）

リストは可変長のコレクションで、要素の追加・削除が容易です。

```cs
// Listの宣言と初期化
List<int> numbers = new List<int>(); // 空のリスト
List<string> names = new List<string> { "佐藤", "鈴木", "田中" }; // 初期値あり

// 要素の追加
numbers.Add(10);
numbers.Add(20);
names.Add("伊藤");

// 要素の挿入
numbers.Insert(1, 15); // インデックス1の位置に15を挿入

// 要素の削除
numbers.Remove(10); // 値10を削除
names.RemoveAt(0); // インデックス0の要素を削除

// 要素の存在確認
bool exists = names.Contains("鈴木"); // trueを返す
```

#### リストの特徴と使用場面

-   **長所**: サイズが可変、豊富なメソッド提供
-   **短所**: 配列より若干遅い、メモリ使用量が多い
-   **使用場面**: サイズが変わるデータの集合（例：ユーザー入力データ、動的に変化するデータ）

### 3. ディクショナリ（Dictionary<TKey, TValue>）

ディクショナリはキーと値のペアを格納するコレクションです。

```cs
// Dictionaryの宣言と初期化
Dictionary<string, int> ages = new Dictionary<string, int>();
Dictionary<int, string> idToName = new Dictionary<int, string> {
    { 1, "佐藤" },
    { 2, "鈴木" },
    { 3, "田中" }
};

// 要素の追加
ages["佐藤"] = 30;
ages["鈴木"] = 25;
ages.Add("田中", 40); // Add メソッドでも追加可能

// 値の取得
int suzukiAge = ages["鈴木"]; // 25

// キーの存在確認
if (ages.ContainsKey("伊藤")) {
    // キーが存在する場合の処理
}

// 安全に値を取得
if (ages.TryGetValue("伊藤", out int itoAge)) {
    // 値が存在する場合の処理
} else {
    // 値が存在しない場合の処理
}

// すべてのキーと値を列挙
foreach (var pair in ages) {
    Console.WriteLine($"{pair.Key}: {pair.Value}歳");
}
```

#### ディクショナリの特徴と使用場面

-   **長所**: キーによる高速なルックアップ、キーと値の明確な関連付け
-   **短所**: キーは一意である必要がある、メモリ使用量が多い
-   **使用場面**: キーと値のマッピング（例：ID と名前、設定値の格納）

### 4. ハッシュセット（HashSet<T>）

ハッシュセットは重複のない要素を格納するコレクションです。

```cs
// HashSetの宣言と初期化
HashSet<int> uniqueNumbers = new HashSet<int>();
HashSet<string> uniqueNames = new HashSet<string> { "佐藤", "鈴木", "田中" };

// 要素の追加（重複は無視される）
uniqueNumbers.Add(10);
uniqueNumbers.Add(20);
uniqueNumbers.Add(10); // 既に存在するので追加されない

// 要素の存在確認
bool exists = uniqueNames.Contains("鈴木"); // trueを返す

// セット演算
HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
HashSet<int> set2 = new HashSet<int> { 2, 3, 4 };

set1.UnionWith(set2); // 和集合: {1, 2, 3, 4}
// その他: IntersectWith（積集合）、ExceptWith（差集合）など
```

#### ハッシュセットの特徴と使用場面

-   **長所**: 要素の重複を許さない、高速な検索
-   **短所**: 順序が保証されない
-   **使用場面**: 重複を排除したいデータの集合（例：一意の ID リスト）

### 5. キュー（Queue<T>）とスタック（Stack<T>）

キューは先入れ先出し（FIFO）、スタックは後入れ先出し（LIFO）のデータ構造です。

```cs
// キューの宣言と初期化
Queue<string> customerQueue = new Queue<string>();
customerQueue.Enqueue("佐藤"); // 列の最後に追加
customerQueue.Enqueue("鈴木");
customerQueue.Enqueue("田中");

string nextCustomer = customerQueue.Dequeue(); // "佐藤"を取り出し
string peekCustomer = customerQueue.Peek(); // "鈴木"を覗き見（削除しない）

// スタックの宣言と初期化
Stack<int> numberStack = new Stack<int>();
numberStack.Push(10); // スタックに追加
numberStack.Push(20);
numberStack.Push(30);

int topNumber = numberStack.Pop(); // 30を取り出し
int peekNumber = numberStack.Peek(); // 20を覗き見（削除しない）
```

#### キューとスタックの特徴と使用場面

-   **キューの使用場面**: 順番に処理するデータ（例：印刷待ちタスク、メッセージキュー）
-   **スタックの使用場面**: 最新のデータを優先的に処理（例：操作の取り消し履歴、再帰処理）

### 6. コレクションの選び方

| コレクション                     | 主な特徴                       | 最適な用途                     |
| -------------------------------- | ------------------------------ | ------------------------------ |
| 配列 (Array)                     | 固定長、高速アクセス           | サイズが変わらないデータの格納 |
| リスト (List<T>)                 | 可変長、要素の追加・削除が容易 | 動的に変化するデータの格納     |
| ディクショナリ (Dictionary<K,V>) | キーと値のペア、高速検索       | キーによる値のルックアップ     |
| ハッシュセット (HashSet<T>)      | 重複なし、高速検索             | 一意の要素を扱う場合           |
| キュー (Queue<T>)                | FIFO（先入れ先出し）           | 順番に処理すべきデータ         |
| スタック (Stack<T>)              | LIFO（後入れ先出し）           | 最新データを優先的に処理       |

### 7. コレクションの使用時の留意点

1. **適切なコレクションの選択**:

    - データの性質（固定/可変、順序の重要性など）
    - 操作の頻度（読み取り優先か追加/削除優先か）
    - メモリ効率と実行速度のバランス

2. **パフォーマンス考慮**:

    - 大量のデータを扱う場合、適切なコレクションを選ぶことが重要
    - 例: 頻繁な検索操作が必要な場合は Dictionary や HashSet が有利

3. **ジェネリックコレクションの活用**:

    - 型安全性を確保するため、非ジェネリックコレクション（ArrayList, Hashtable など）よりもジェネリックコレクションを優先する

4. **並列処理時の注意**:

    - 複数スレッドからアクセスする場合は、`ConcurrentDictionary<K,V>`などのスレッドセーフなコレクションを使用する
    - または適切な同期処理を実装する

5. **メモリ管理**:

    - 不要になったコレクションは null を代入して、ガベージコレクションの対象にする
    - 大きなコレクションは使用後に`Clear()`メソッドで要素を解放する

## デリゲート

### デリゲートとは

デリゲートは、C#におけるメソッドを参照するための型です。TypeScript の関数型（Function type）に近い概念で、メソッドを変数のように扱い、実行時に動的にメソッドを切り替えることができる強力な機能です。TypeScript では関数をファーストクラスオブジェクトとして扱いますが、C#ではデリゲートという特別な型を通じてメソッドを参照します。

### TypeScript ユーザーのためのデリゲート解説

TypeScript では関数型を以下のように定義します：

```typescript
// TypeScriptの関数型
type Calculator = (x: number, y: number) => number;

// 使用例
const add: Calculator = (x, y) => x + y;
const subtract: Calculator = (x, y) => x - y;

// 関数の使用
const result = add(5, 3); // 8
```

C#のデリゲートは以下のように定義され、同様の機能を提供します：

```csharp
// C#のデリゲート
public delegate int Calculate(int x, int y);

// 使用例
public int Add(int x, int y) { return x + y; }
public int Subtract(int x, int y) { return x - y; }

Calculator calc = Add;
int result = calc(5, 3); // 8
```

TypeScript の関数型と C#のデリゲートの主な違いは、デリゲートが型システムの中で明示的に定義される点です。TypeScript では関数は直接変数に代入できますが、C#ではデリゲート型を介して関数参照を行います。

### デリゲートの宣言と使用方法

デリゲート型は以下のように宣言します：

```csharp
// デリゲートの宣言
public delegate int Calculate(int x, int y);

// デリゲートの使用例
public class Calculator
{
    public int Add(int x, int y) { return x + y; }
    public int Subtract(int x, int y) { return x - y; }

    public void UseDelegate()
    {
        Calculate calc = Add;  // メソッドの割り当て
        int result = calc(5, 3);  // メソッドの実行（結果: 8）

        calc = Subtract;  // 別のメソッドに切り替え
        result = calc(5, 3);  // メソッドの実行（結果: 2）
    }
}
```

TypeScript での同等の実装：

```typescript
class Calculator {
    add(x: number, y: number): number {
        return x + y;
    }
    subtract(x: number, y: number): number {
        return x - y;
    }

    useFunction(): void {
        // TypeScriptではメソッド参照時にthisのバインドに注意
        let calc: (x: number, y: number) => number = this.add.bind(this);
        let result = calc(5, 3); // 8

        calc = this.subtract.bind(this);
        result = calc(5, 3); // 2
    }
}
```

### マルチキャストデリゲート

C#のデリゲートは TypeScript にない特徴としてマルチキャスト機能を持ちます。複数のメソッドを一つのデリゲートに登録し、呼び出し時に順番に実行できます：

```csharp
public delegate void NotifyDelegate(string message);

public class Notification
{
    public void SendEmail(string message) { Console.WriteLine($"Email: {message}"); }
    public void SendSMS(string message) { Console.WriteLine($"SMS: {message}"); }

    public void SetupNotifications()
    {
        NotifyDelegate notifier = SendEmail;
        notifier += SendSMS;  // 複数のメソッドを登録

        notifier("重要なお知らせ");  // 両方のメソッドが順番に実行される
    }
}
```

TypeScript でこれを実現するには、自分で配列を管理する必要があります：

```typescript
type NotifyFunction = (message: string) => void;

class Notification {
    sendEmail(message: string): void {
        console.log(`Email: ${message}`);
    }
    sendSMS(message: string): void {
        console.log(`SMS: ${message}`);
    }

    setupNotifications(): void {
        // 関数の配列を作成して管理
        const notifiers: NotifyFunction[] = [
            this.sendEmail.bind(this),
            this.sendSMS.bind(this),
        ];

        // すべての通知を実行
        notifiers.forEach((notify) => notify("重要なお知らせ"));
    }
}
```

### ビルトインデリゲート型

C#には、よく使用されるデリゲートパターンをカバーする組み込みデリゲート型があります：

-   `Action<T>`: 戻り値を持たないメソッドを表す（TypeScript の `(param: T) => void` に相当）

    ```csharp
    Action<string> logger = Console.WriteLine;
    ```

-   `Func<T, TResult>`: 戻り値を持つメソッドを表す（TypeScript の `(param: T) => TResult` に相当）

    ```csharp
    Func<int, int, int> add = (x, y) => x + y;
    ```

-   `Predicate<T>`: bool 型を戻す条件判定用メソッド（TypeScript の `(param: T) => boolean` に相当）
    ```csharp
    Predicate<int> isPositive = x => x > 0;
    ```

TypeScript では型エイリアスで同様の定義が可能です：

```typescript
// TypeScriptでの同等定義
type Action<T> = (param: T) => void;
type Func<T, U, TResult> = (param1: T, param2: U) => TResult;
type Predicate<T> = (param: T) => boolean;

// 使用例
const logger: Action<string> = console.log;
const add: Func<number, number, number> = (x, y) => x + y;
const isPositive: Predicate<number> = (x) => x > 0;
```

### 実践的な使用例

#### イベント処理の比較

C#のイベント処理（デリゲートベース）：

```csharp
// C#でのイベント
public class Button
{
    // イベントはデリゲートベース
    public event EventHandler Click;

    public void OnClick()
    {
        Click?.Invoke(this, EventArgs.Empty);
    }
}

// 使用例
Button button = new Button();
button.Click += (sender, e) => Console.WriteLine("ボタンがクリックされました");
```

TypeScript での同等実装：

```typescript
// TypeScriptでのイベント
class Button {
    // イベントリスナーの配列
    private clickListeners: Array<(event: Event) => void> = [];

    // リスナー追加メソッド
    addEventListener(listener: (event: Event) => void): void {
        this.clickListeners.push(listener);
    }

    // イベント発火
    onClick(): void {
        const event = new Event("click");
        this.clickListeners.forEach((listener) => listener(event));
    }
}

// 使用例
const button = new Button();
button.addEventListener((event) => console.log("ボタンがクリックされました"));
```

#### コールバックパターン

C#（デリゲートを使用）：

```csharp
public void ProcessData(Action<string> callback)
{
    // データ処理
    string result = "処理完了";
    callback(result);  // 処理完了時にコールバックを実行
}

// 使用例
ProcessData(message => Console.WriteLine($"結果: {message}"));
```

TypeScript（関数を直接渡す）：

```typescript
function processData(callback: (result: string) => void): void {
    // データ処理
    const result = "処理完了";
    callback(result); // コールバック実行
}

// 使用例
processData((message) => console.log(`結果: ${message}`));
```

### サンプルコード：ストラテジーパターン

C#でのストラテジーパターン（デリゲート版）：

```csharp
public class SortStrategy
{
    public void Sort<T>(List<T> items, Func<T, T, bool> compareStrategy)
    {
        // 単純なバブルソート実装
        for (int i = 0; i < items.Count - 1; i++)
        {
            for (int j = 0; j < items.Count - 1 - i; j++)
            {
                if (!compareStrategy(items[j], items[j + 1]))
                {
                    // 要素の入れ替え
                    T temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                }
            }
        }
    }
}

// 使用例
var numbers = new List<int> { 5, 2, 8, 1, 7 };
var sorter = new SortStrategy();

// 昇順ソート
sorter.Sort(numbers, (a, b) => a <= b);
// 結果: [1, 2, 5, 7, 8]

// 降順ソート
sorter.Sort(numbers, (a, b) => a >= b);
// 結果: [8, 7, 5, 2, 1]
```

TypeScript での同等実装：

```typescript
class SortStrategy {
    sort<T>(items: T[], compareStrategy: (a: T, b: T) => boolean): void {
        // 単純なバブルソート実装
        for (let i = 0; i < items.length - 1; i++) {
            for (let j = 0; j < items.length - 1 - i; j++) {
                if (!compareStrategy(items[j], items[j + 1])) {
                    // 要素の入れ替え
                    const temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                }
            }
        }
    }
}

// 使用例
const numbers = [5, 2, 8, 1, 7];
const sorter = new SortStrategy();

// 昇順ソート
sorter.sort(numbers, (a, b) => a <= b);
// 結果: [1, 2, 5, 7, 8]

// 降順ソート
sorter.sort(numbers, (a, b) => a >= b);
// 結果: [8, 7, 5, 2, 1]
```

C#のデリゲートは TypeScript の関数型と似た概念ですが、型システムでの扱い方やマルチキャスト機能など異なる点もあります。TypeScript の関数をファーストクラスオブジェクトとして扱う経験があれば、C#のデリゲートも直感的に理解しやすいでしょう。どちらも関数型プログラミングの要素を取り入れ、柔軟なコード設計を可能にする重要な機能です。

## 例外処理

### 例外処理とは

例外処理は、プログラム実行中に発生する予期しないエラーや異常な状態を検出し、適切に対応するための仕組みです。C#の例外処理は、TypeScript の例外処理と基本的な概念は似ていますが、特有の機能や構文の違いがあります。

### C#と TypeScript の例外処理の比較

#### 基本構文

C#の例外処理基本構文：

```csharp
try
{
    // 例外が発生する可能性のあるコード
    int result = 10 / 0; // ゼロ除算例外が発生
}
catch (DivideByZeroException ex)
{
    // 特定の例外をキャッチ
    Console.WriteLine($"ゼロ除算エラー: {ex.Message}");
}
catch (Exception ex)
{
    // その他のすべての例外をキャッチ
    Console.WriteLine($"エラーが発生しました: {ex.Message}");
}
finally
{
    // 例外の有無にかかわらず実行されるコード
    Console.WriteLine("処理を終了します");
}
```

TypeScript の例外処理基本構文：

```typescript
try {
    // 例外が発生する可能性のあるコード
    const result = 10 / 0; // JavaScriptではInfinityとなり例外は発生しない
    throw new Error("例外のデモ");
} catch (error) {
    // TypeScriptでは例外の型を区別しづらい
    console.log(`エラーが発生しました: ${error.message}`);
} finally {
    // 例外の有無にかかわらず実行されるコード
    console.log("処理を終了します");
}
```

### C#の例外処理の特徴

#### 1. 型階層による例外の区別

C#では、例外は `System.Exception` クラスから派生した型階層を持ちます。これにより、発生した例外の種類に応じて異なる処理が可能です：

```csharp
try
{
    using (StreamReader file = new StreamReader("存在しないファイル.txt"))
    {
        string content = file.ReadToEnd();
    }
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"ファイルが見つかりません: {ex.FileName}");
}
catch (IOException ex)
{
    Console.WriteLine($"入出力エラー: {ex.Message}");
}
```

TypeScript では例外の型階層が弱く、通常は `instanceof` を使って例外の種類を判別します：

```typescript
try {
    // ファイル操作など
} catch (error) {
    if (error instanceof TypeError) {
        console.log("型エラーです");
    } else {
        console.log("その他のエラーです");
    }
}
```

#### 2. 例外フィルター (C# 6.0 以降)

C#では when キーワードを使用して例外フィルターを定義できます：

```csharp
try
{
    int number = int.Parse("abc");
}
catch (FormatException ex) when (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
{
    Console.WriteLine("月曜日に発生したフォーマットエラー");
}
catch (FormatException ex)
{
    Console.WriteLine("通常のフォーマットエラー");
}
```

TypeScript にはこの機能に直接対応するものはなく、catch ブロック内で条件分岐を行う必要があります。

#### 3. カスタム例外の定義

C#でカスタム例外を定義する場合：

```csharp
// カスタム例外クラスの定義
public class UserNotFoundException : Exception
{
    public string Username { get; }

    public UserNotFoundException(string username)
        : base($"ユーザー '{username}' が見つかりませんでした")
    {
        Username = username;
    }
}

// 使用例
try
{
    string username = "admin";
    bool exists = false;

    if (!exists)
    {
        throw new UserNotFoundException(username);
    }
}
catch (UserNotFoundException ex)
{
    Console.WriteLine($"エラー: {ex.Message}, ユーザー名: {ex.Username}");
}
```

TypeScript でのカスタム例外の例：

```typescript
class UserNotFoundException extends Error {
    username: string;

    constructor(username: string) {
        super(`ユーザー '${username}' が見つかりませんでした`);
        this.name = "UserNotFoundException";
        this.username = username;
    }
}

try {
    const username = "admin";
    const exists = false;

    if (!exists) {
        throw new UserNotFoundException(username);
    }
} catch (error) {
    if (error instanceof UserNotFoundException) {
        console.log(`エラー: ${error.message}, ユーザー名: ${error.username}`);
    }
}
```

### 例外処理のベストプラクティス

#### 1. 例外の捕捉と再スロー

より詳細な情報を追加して例外を再スローする方法：

```csharp
try
{
    // リソースへのアクセス
}
catch (Exception ex)
{
    // ログ記録
    Logger.Log(ex);

    // 追加情報を含めて再スロー
    throw new ApplicationException("データベース接続中にエラーが発生しました", ex);
}
```

TypeScript での同様の処理：

```typescript
try {
    // リソースへのアクセス
} catch (error) {
    // ログ記録
    logger.log(error);

    // 新しい例外を作成して元の例外を含める
    const newError = new Error("データベース接続中にエラーが発生しました");
    newError.cause = error; // ES2022の機能
    throw newError;
}
```

#### 2. リソース管理 (IDisposable と using)

C#では、`using` ステートメントを使用してリソースの確実な解放を実現します：

```csharp
try
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        // データベース処理
    } // ここで自動的に connection.Dispose() が呼ばれる
}
catch (SqlException ex)
{
    Console.WriteLine($"SQLエラー: {ex.Message}");
}
```

TypeScript には直接対応する機能はなく、通常は try/finally または明示的なクローズ処理を実装します：

```typescript
let connection = null;
try {
    connection = new DatabaseConnection();
    connection.open();
    // データベース処理
} catch (error) {
    console.log(`データベースエラー: ${error.message}`);
} finally {
    if (connection) {
        connection.close();
    }
}
```

#### 3. 非同期処理での例外処理

C#の async/await での例外処理：

```csharp
public async Task<string> FetchDataAsync()
{
    try
    {
        using (HttpClient client = new HttpClient())
        {
            string response = await client.GetStringAsync("https://api.example.com/data");
            return response;
        }
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"HTTP要求エラー: {ex.Message}");
        return null;
    }
}
```

TypeScript での非同期例外処理：

```typescript
async function fetchData(): Promise<string> {
    try {
        const response = await fetch("https://api.example.com/data");
        if (!response.ok) {
            throw new Error(`HTTP error ${response.status}`);
        }
        return await response.text();
    } catch (error) {
        console.log(`取得エラー: ${error.message}`);
        return null;
    }
}
```

### 注意点とガイドライン

1. **例外を適切に使用する**:

    - 例外は予期しない状況やエラー処理のためのものであり、通常のフロー制御には使用しない
    - パフォーマンスへの影響を考慮する（例外処理はコストが高い操作）

2. **具体的な例外をキャッチする**:

    - `catch (Exception)` のような一般的な例外捕捉より、具体的な例外型を指定する
    - 複数の catch ブロックを使い、例外タイプごとに適切な対応を行う

3. **例外情報の保持**:

    - 例外を再スローする場合は `throw;` を使用して、スタックトレース情報を保持する
    - `throw ex;` は新しいスタックトレースを生成し、元の情報が失われる

4. **リソースの解放を保証する**:
    - リソースを使用する場合は、`using` ステートメントや `try-finally` パターンを活用する
    - `IDisposable` インターフェースを実装したクラスで確実なリソース解放を行う

C#の例外処理は TypeScript のそれと概念的には似ていますが、型の階層構造や例外フィルターなど、より細かな制御が可能な点が特徴です。TypeScript の知識を活かしつつ、C#特有の例外処理のパターンを学ぶことで、より堅牢なアプリケーションを作成できるようになります。

## トップレベルステートメントとは

### トップレベルステートメントとは

トップレベルステートメントは、C# 9.0（.NET 5）から導入された機能で、Main メソッドを含むクラスの定義を省略して、プログラムの最上位レベルで直接コードを記述できるようにする機能です。これにより、特に小規模なプログラムやスクリプトのようなコードでは、より簡潔に記述することが可能になりました。

### 言語間の比較: C#、TypeScript、従来の C#

#### TypeScript と JavaScript

元々の設計からファイルの最上位レベルでコードを書くことができます：

```typescript
// TypeScriptの例 - 最上位レベルでのコード記述
console.log("Hello, World!");

function add(a: number, b: number): number {
    return a + b;
}

const result = add(5, 3);
console.log(result);
```

#### 現代の C#（C# 9.0 以降）

トップレベルステートメントを使用することで、TypeScript のような簡潔な記述が可能になりました：

```csharp
// トップレベルステートメントを使用したC#プログラム
using System;

Console.WriteLine("Hello, World!");
int result = Add(5, 3);
Console.WriteLine(result);

int Add(int a, int b)
{
    return a + b;
}
```

TypeScript ユーザーにとっては、この新しい C#の記法は馴染みやすく、余分なボイラープレートコードがなくなったことで、より直感的にコードを書くことができるようになりました。

#### 従来の C#（C# 9.0 以前）

クラスと Main メソッドの定義が必須でした：

```csharp
// 従来のC#プログラム
using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int result = Add(5, 3);
            Console.WriteLine(result);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
```

### トップレベルステートメントの特徴

1. **暗黙的な Main メソッド**：

    - コンパイラが自動的に Main メソッドを生成します
    - コマンドライン引数は`args`という名前の変数で利用可能です

2. **スコープの制約**：

    - 一つのプロジェクトで一つのファイルのみがトップレベルステートメントを持つことができます
    - 複数のファイルにトップレベルステートメントがあるとコンパイルエラーになります

3. **トップレベルの関数、型、名前空間宣言**：
    - トップレベルで関数を定義できます
    - トップレベルステートメントの後にクラスやレコード、構造体などの型定義を記述できます
    - トップレベルステートメントが含まれるファイルで名前空間を宣言することができます

```csharp
// トップレベルステートメントと型定義の混在
using System;

// トップレベルステートメント部分
Console.WriteLine("プログラム開始");
var person = new Person("山田", "太郎");
Console.WriteLine($"こんにちは、{person.FullName}さん");

// トップレベル関数
string FormatGreeting(string name)
{
    return $"こんにちは、{name}さん！";
}

// 型定義部分
public class Person
{
    public string FirstName { get; }
    public string LastName { get; }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FullName => $"{LastName} {FirstName}";
}
```

### 戻り値の指定

トップレベルステートメントでは、`return`文を使用してプログラムの終了コードを指定することができます：

```csharp
using System;

if (args.Length == 0)
{
    Console.WriteLine("引数が指定されていません");
    return 1; // 終了コード 1 を返す
}

Console.WriteLine($"引数: {string.Join(", ", args)}");
return 0; // 正常終了（終了コード 0）
```

### トップレベルステートメントの利点

1. **コードの簡潔さ**：

    - 小規模なプログラムやユーティリティでの定型コードを削減
    - 学習者が C#を始める際の理解のハードルを下げる

2. **スクリプト的な使用**：

    - コンソールアプリケーションや小さなユーティリティの開発が容易に
    - .NET Interactive や Jupyter ノートブックなどでの使用に適している

3. **タスク指向のプログラミング**：
    - ボイラープレートコードではなく、実際の機能実装に集中できる

### 制限事項と注意点

1. **一つのプロジェクトに一つだけ**：

    - 複数のファイルでトップレベルステートメントを使用することはできない

2. **大規模プロジェクトには向かない**：

    - 大規模な構造化されたアプリケーションには従来の方式が適している

3. **グローバル変数のような振る舞い**：
    - トップレベルステートメントの変数はファイル内でグローバルに見えるため、大きなプログラムでは混乱の原因になりうる

### 実用的な使用例

**Web スクレイピングのスクリプト：**

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;

// 非同期のトップレベルステートメントも可能
await ScrapeWebsiteAsync();

async Task ScrapeWebsiteAsync()
{
    using var client = new HttpClient();
    string url = "https://example.com";

    try
    {
        string content = await client.GetStringAsync(url);
        Console.WriteLine($"取得したコンテンツ長: {content.Length}文字");
        // ここで内容を解析
    }
    catch (Exception ex)
    {
        Console.WriteLine($"エラー: {ex.Message}");
        Environment.Exit(1);
    }
}
```

トップレベルステートメントは、C#をよりモダンでアクセスしやすい言語にするための重要な進化の一つです。TypeScript から C#に移行する開発者にとっては、馴染みやすい構文になっていると言えるでしょう。
