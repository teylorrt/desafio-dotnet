import { useEffect, useState } from "react";
import type { Operation } from "../../classes/operation";
import { FileUploadForm } from "../../components/FileUploadForm/FileUploadForm";
import { OperationTable } from "../../components/OperationTable/OperationTable";

export const Operations: React.FC = () => {
  const [fileUploaded, setFileUploaded] = useState<boolean>(false);
  const [operations, setOperations] = useState<Operation[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);
  

  useEffect(() => {
    if(fileUploaded) {
        fetchOperations();
        // setFileUploaded(false);
    }
  }, [fileUploaded]);

  const fetchOperations = async () => {
      try {
        const response = await fetch('http://localhost:5252/api/operation/list');
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data: Operation[] = await response.json();
        setOperations(data);
      } catch (err: any) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
};

  if (loading) return <div>Loading operations...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <>
      <h1>Import Operations</h1>
      <FileUploadForm setFileUploaded={setFileUploaded} />
      <OperationTable operations={operations} />
    </>
  );
};