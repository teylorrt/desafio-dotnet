import { useEffect, useState } from "react";
import type { OperationGroupModel } from "../../classes/operation";
import { FileUploadForm } from "../../components/FileUploadForm/FileUploadForm";
import { OperationTable } from "../../components/OperationTable/OperationTable";

export const Operations: React.FC = () => {
  const [fileUploaded, setFileUploaded] = useState<boolean>(false);
  const [operationGroups, setOperationGroups] = useState<OperationGroupModel[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  

  useEffect(() => {
    if(fileUploaded || loading) {
        fetchOperations();
        setLoading(false);
        setFileUploaded(false);
    }
  }, [fileUploaded]);

  useEffect(() => {
    if(operationGroups) {
      setLoading(false);
    }
  }, [operationGroups]);

  const setSuccessUpload = () => {
    setFileUploaded(true);
  };

  const fetchOperations = () => {
      try {
        setLoading(true);
        fetch('http://localhost:5252/api/operation/list-by-store')
        .then(async (response) => {
          if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
          }
          return await response.json();
        })
        .then((data: OperationGroupModel[]) => {
          setOperationGroups(data);
        })
        .catch((err: any) => {
          setError(err.message);
        })
        .finally(() => {
          setLoading(false);
        });
      } catch (err: any) {
        setError(err.message);
        setLoading(false);
      }
    }

  if (loading) return <div>Loading operations...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <>
      <h1>Import Operations</h1>
      <FileUploadForm setSuccessUpload={setSuccessUpload} />
      <h1>Imported Operations</h1>
      {operationGroups?.map((group) => (
        <OperationTable
          key={group.name}
          title={group.name}
          accountBalance={group.accountBalance}
          operations={group.operations}
        />
      ))}
    </>
  );
};