using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT191P_Project.App_Code
{
    public class _Transaction
    {
        string transactionId, trackingNo, destination, type, status;
        int custID, source;
        double payment;

        public _Transaction(string transactionId, string trackingNo, int custID, int source, string destination, string status, string type, double payment)
        {
            this.transactionId = transactionId;
            this.trackingNo = trackingNo;
            this.custID = custID;
            this.source = source;
            this.destination = destination;
            this.status = status;
            this.type = type;
            this.payment = payment;
        }

        public string TransactionId
        {
            get { return transactionId; }
            set { transactionId = value; }
        }

        public string TrackingNo
        {
            get { return trackingNo; }
            set { trackingNo = value; }
        }

        public int CustomerId
        {
            get { return custID; }
            set { custID = value; }
        }

        public int Source
        {
            get { return source; }
            set { source = value; }
        }

        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Amount
        {
            get { return payment; }
            set { payment = value; }
        }
    }
}