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
