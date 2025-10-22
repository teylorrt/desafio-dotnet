import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { FileUploadForm } from './components/FileUploadForm/FileUploadForm'
import type { Operation } from './classes/operation'
import { OperationTable } from './components/OperationTable/OperationTable'

function App() {
  const [count, setCount] = useState(0)

  const operations: Operation[] = [
    { id: 1, name: 'Deposit', amount: 100, date: '2023-01-01' },
    { id: 2, name: 'Withdrawal', amount: 50, date: '2023-01-02' },
    { id: 3, name: 'Transfer', amount: 200, date: '2023-01-03' },
  ];

  return (
    <>
      <h1>Import Operations</h1>
      <FileUploadForm />
      <OperationTable operations={operations} />
    </>
  )
}

export default App
