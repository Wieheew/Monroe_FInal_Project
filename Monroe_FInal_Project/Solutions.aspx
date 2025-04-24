<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solutions.aspx.cs" Inherits="Monroe_FInal_Project.Solutions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-
EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="CmdShowSolution753" runat="server" Text="Solution 753" OnClick="CmdShowSolution753_Click" />
            <asp:Button ID="CmdShowSolution123" runat="server" Text="Solution 123" OnClick="CmdShowSolution123_Click" />
            <asp:Button ID="CmdShowSolution68" runat="server" Text="Solution 68"  OnClick="CmdShowSolution68_Click"/>
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="CmdClear_Click"/>
            <br /><br />
            <strong>Problem:</strong><br />
            <asp:Label ID="lblProblem" runat="server" Text="" />
            <br /><br />
            <strong>Solution:</strong><br />
            <asp:Label ID="lblSolution" runat="server" Text="" ForeColor="DarkGreen" />
            <pre style="font-family: Consolas; background-color: #f4f4f4; padding: 10px;">
    <asp:Literal ID="litSolution" runat="server" />
</pre>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-
MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    </form>
</body>
</html>
