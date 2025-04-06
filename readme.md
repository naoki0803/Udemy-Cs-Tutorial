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

## コードフォーマット関連

omnisharp は現状利用しておらず、C# Div Kit 内の機能でフォーマットしていそうだが、その設定実体がどこかがわからない。

.editorconfig を記述しても、記述がうまく反映しない。
原因不明。。。

以下 URL に記載しているサンプルフォーマットテンプレート
https://tech-blog.cloud-config.jp/2020-12-18-visual-studio-code-for-csharp-development/

~/.omnisharp/omnisharp.json に記述するか、プロジェクトのルートに記述する(.omnisharp/omnisharp.json)

```omnisharp.json
{
    "FormattingOptions": {
        "EnableEditorConfigSupport": false,
        "NewLine": "\n",
        "UseTabs": false,
        "TabSize": 2,
        "IndentationSize": 2,
        "SpacingAfterMethodDeclarationName": false,
        "SpaceWithinMethodDeclarationParenthesis": false,
        "SpaceBetweenEmptyMethodDeclarationParentheses": false,
        "SpaceAfterMethodCallName": false,
        "SpaceWithinMethodCallParentheses": false,
        "SpaceBetweenEmptyMethodCallParentheses": false,
        "SpaceAfterControlFlowStatementKeyword": true,
        "SpaceWithinExpressionParentheses": false,
        "SpaceWithinCastParentheses": false,
        "SpaceWithinOtherParentheses": false,
        "SpaceAfterCast": false,
        "SpacesIgnoreAroundVariableDeclaration": false,
        "SpaceBeforeOpenSquareBracket": false,
        "SpaceBetweenEmptySquareBrackets": false,
        "SpaceWithinSquareBrackets": false,
        "SpaceAfterColonInBaseTypeDeclaration": true,
        "SpaceAfterComma": true,
        "SpaceAfterDot": false,
        "SpaceAfterSemicolonsInForStatement": true,
        "SpaceBeforeColonInBaseTypeDeclaration": true,
        "SpaceBeforeComma": false,
        "SpaceBeforeDot": false,
        "SpaceBeforeSemicolonsInForStatement": false,
        "SpacingAroundBinaryOperator": "single",
        "IndentBraces": false,
        "IndentBlock": true,
        "IndentSwitchSection": true,
        "IndentSwitchCaseSection": true,
        "IndentSwitchCaseSectionWhenBlock": true,
        "LabelPositioning": "oneLess",
        "WrappingPreserveSingleLine": true,
        "WrappingKeepStatementsOnSingleLine": true,
        "NewLinesForBracesInTypes": true,
        "NewLinesForBracesInMethods": true,
        "NewLinesForBracesInProperties": true,
        "NewLinesForBracesInAccessors": true,
        "NewLinesForBracesInAnonymousMethods": true,
        "NewLinesForBracesInControlBlocks": true,
        "NewLinesForBracesInAnonymousTypes": true,
        "NewLinesForBracesInObjectCollectionArrayInitializers": true,
        "NewLinesForBracesInLambdaExpressionBody": true,
        "NewLineForElse": true,
        "NewLineForCatch": true,
        "NewLineForFinally": true,
        "NewLineForMembersInObjectInit": true,
        "NewLineForMembersInAnonymousTypes": true,
        "NewLineForClausesInQuery": true,
        "OrganizeImports": true
    },
    "RoslynExtensionsOptions": {
        "documentAnalysisTimeoutMs": 10000,
        "enableDecompilationSupport": true,
        "enableImportCompletion": true,
        "enableAnalyzersSupport": true,
        "locationPaths": ["//path_to/code_actions.dll"]
    }
}

```
