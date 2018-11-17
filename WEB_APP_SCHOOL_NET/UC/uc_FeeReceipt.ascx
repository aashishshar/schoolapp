<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_FeeReceipt.ascx.cs" Inherits="WEB_APP_SCHOOL_NET.UC.uc_FeeReceipt" %>

<style>
    /* Important part */
    .modal-dialog {
        overflow-y: initial !important;
    }

    .modal-body {
        height: 768px;
        overflow-y: auto;
    }
</style>
<div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog" style="width: 58%">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Student Fee Receipt</h4>
            </div>
            <div class="modal-body" id="PrintData">
                <div class="row pull-right">
                    <a href="#" class="btn btn-success" onclick='print("PrintData");'><i class="fa fa-print"></i>&nbsp;Print All</a>
                </div>
                <div class="row">
                    <table style="width: 100%" id="SchoolDetails">
                        <tr >
                            <td>
                                <img src='<%=SchoolImage %>' height="115" width="125" /></td>
                            <td >
                                <h3><%=SchoolName %></h3>
                               
                                <h5><%=SchoolAddress %></h5>
                            </td>

                        </tr>
                    </table>
                    <br />
                    <b>Student Name : </b><%=StudentName %><br />
                    <b>Father's Name : </b><%=FathersName %><br />
                    <b>Form Number : </b><%=FormNumber %>
                </div>
                <% int Count = 0; %>
                <% foreach (var item in WEB_APP_SCHOOL_NET.UC.uc_FeeReceipt.lsDuplicate)
                   {%>
                <div class="row">
                    <a href="#" class="btn btn-success pull-right" onclick='printLocal("<%="PrintData" + Count %>");'><i class="fa fa-print"></i>&nbsp;Print</a>
                </div>
                <br />
                <div class="printData" id='<%= "PrintData"+Count %>'>
                    <%Count++; %>
                    <div class="SchoolNameLocal row" style="display: none;">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <img src='<%=SchoolImage %>' height="115" width="125" /></td>
                                <td style="text-align: center;">
                                    <h3><%=SchoolName %></h3>
                                    
                                    <h5><%=SchoolAddress %></h5>
                                </td>

                            </tr>
                        </table>
                        <br />
                        <b>Student Name : </b><%=StudentName %><br />
                        <b>Father's Name : </b><%=FathersName %><br />
                        <b>Form Number : </b><%=FormNumber %>
                    </div>
                    <br />
                    <div class="row">
                        <table style="width: 100%">
                            <tr style="width: 100%">
                                <td width="68%">
                                    <b>Receipt Number : 
                                    <%= item.ReceiptNumber %></b></td>
                                <td style="text-align: right;"><b>Date :  
                                    <%= item.SubmitDate %></b></td>
                            </tr>
                        </table>
                        <br />
                        <% Decimal totalFee = 0; %>
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th style="width: 89%;">Particulars</th>
                                    <th style="width: 11%;">Amount(Rs.)</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var item2 in WEB_APP_SCHOOL_NET.UC.uc_FeeReceipt.lsReceipts)
                                   {%>
                                <%if (item2.ReceiptNumber == item.ReceiptNumber)
                                  { %>
                                <tr>
                                    <td style="text-align: left;"><%=item2.FeeName %></td>
                                    <td style="text-align: right;"><%=item2.TotalFee%></td>
                                    <%  totalFee = totalFee + Convert.ToDecimal(item2.TotalFee);%>
                                </tr>
                                <%  }

                                  totalFee.ToString();
                                   } %>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td style="text-align: right;"><b>Total:</b></td>
                                    <td style="text-align: right;">
                                        <b><%=totalFee.ToString()%></b></td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
                <%  } %>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>

    </div>
</div>
<script>
    function print(Id) {
        $('.btn').hide();
        $('#SchoolDetails').find('tr').children('td').first().removeAttr("width");
        $('#SchoolDetails').find('tr').children('td').first().attr("width", "50%");
        printJS(Id, "html");
        $('#SchoolDetails').find('tr').children('td').first().removeAttr("width");
        $('#SchoolDetails').find('tr').children('td').first().attr("width", "39%");
        $('.btn').show();

    }
    function printLocal(Id) {
        var newId = '#' + Id;
        $(newId).addClass('modal-body');
        $('.SchoolNameLocal').show();
        printJS(Id, "html");
        $('.SchoolNameLocal').hide();
        $(newId).removeClass('modal-body');
    }


</script>
