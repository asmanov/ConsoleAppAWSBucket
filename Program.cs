using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.Runtime;
using Amazon.S3.Model;


class S3Uploader
{
    static async Task Main(string[] args)
    {
        BasicAWSCredentials credentials = new BasicAWSCredentials("", "");
        IAmazonS3 client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1);
        string bucketName = "";
        string keyName = "";
        string filePath = @"C:\Users\АсмановОлексійАлійов\Downloads\20231105_152028.jpg";

        try
        {
            // Upload the file to Amazon S3
            TransferUtility fileTransferUtility = new TransferUtility(client);
            fileTransferUtility.Upload(filePath, bucketName, keyName);
            Console.WriteLine("Upload completed!");
            fileTransferUtility.Download(@"C:\Users\АсмановОлексійАлійов\Downloads\!!!!20231105_152058.jpg", bucketName, "20231105_152058.jpg");
            Console.WriteLine("Download completed");
        }
        catch (AmazonS3Exception e)
        {
            Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
        }
        
    }
}
