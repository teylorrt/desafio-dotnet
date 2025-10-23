import React, { useState, useRef } from 'react';

export interface FileUploadFormProps {
    setSuccessUpload: (value: boolean) => void;
}

export const FileUploadForm: React.FC<FileUploadFormProps> = ({ setSuccessUpload }) => {
  const [selectedFile, setSelectedFile] = useState<File | null>(null);
  const fileInputRef = useRef<HTMLInputElement>(null); // For programmatic click

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files && event.target.files.length > 0) {
      setSelectedFile(event.target.files[0]);
    } else {
      setSelectedFile(null);
    }
  };

  const handleFormSubmit = async (event: React.FormEvent) => {
    event.preventDefault(); // Prevent default form submission
    if (!selectedFile) {
      alert('Please select a file to upload.');
      return;
    }

    const formData = new FormData();
    formData.append('file', selectedFile);

    try {
      // Replace with your actual upload API endpoint
      const response = await fetch('http://localhost:5252/api/operation/import', {
        method: 'POST',
        body: formData,
      });

      if (response.ok) {
        setSelectedFile(null); // Clear selected file after upload
        setSuccessUpload(true);
        if (fileInputRef.current) {
          fileInputRef.current.value = ''; // Reset file input
        }
      } else {
        setSuccessUpload(false);
        console.error('File upload failed:', response.statusText);
        alert('File upload failed.');
      }
    } catch (error) {
        setSuccessUpload(false);
        console.error('Error during file upload:', error);
        alert('An error occurred during file upload.');
    }
  };

  const handleButtonClick = () => {
    fileInputRef.current?.click(); // Programmatically click the hidden file input
  };

  return (
    <form onSubmit={handleFormSubmit}>
      <input
        type="file"
        ref={fileInputRef}
        onChange={handleFileChange}
        style={{ display: 'none' }} // Hide the default file input
      />
      <button type="button" onClick={handleButtonClick}>
        {selectedFile ? selectedFile.name : 'Select File'}
      </button>
      {selectedFile && (
        <p>Selected: {selectedFile.name}</p>
      )}
      <button type="submit" disabled={!selectedFile}>
        Upload
      </button>
    </form>
  );
};