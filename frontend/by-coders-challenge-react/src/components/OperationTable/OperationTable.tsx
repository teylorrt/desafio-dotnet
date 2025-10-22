import React from 'react';
import type { Operation } from '../../classes/operation';
import { Table } from '../Table/Table';

export interface OperationTableProps {
  operations: Operation[];
}

export const OperationTable: React.FC<OperationTableProps> = ({ operations }) => {

  const headers = ['ID', 'Name', 'Amount', 'Date'];

    const renderOperationRow = (operation: Operation) => (
    <>
        <td>{operation.id}</td>
        <td>{operation.name}</td>
        <td>{operation.amount}</td>
        <td>{operation.date}</td>
    </>
    );

  return (
    <div>
      <h1>Imported Operations</h1>
      <Table headers={headers} data={operations} renderRow={renderOperationRow} />
    </div>
  );
}