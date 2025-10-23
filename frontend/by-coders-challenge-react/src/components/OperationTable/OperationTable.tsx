import React from 'react';
import type { Operation } from '../../classes/operation';
import { Table } from '../Table/Table';
import { cpfMask, valueMask } from '../../util/maskUtil';

export interface OperationTableProps {
  title: string;
  operations: Operation[];
  accountBalance: number;
}

export const OperationTable: React.FC<OperationTableProps> = ({ title, operations, accountBalance }) => {

  const headers = ['ID', 'Type', 'Description', 'Nature', 'Sign', 'Time', 'Value', 'CPF', 'Card', 'Store Owner', 'Store Name'];

    const renderOperationRow = (operation: Operation) => (
    <>
        <td>{operation.id}</td>
        <td>{operation.type}</td>
        <td>{operation.description}</td>
        <td>{operation.nature}</td>
        <td>{operation.sign}</td>
        <td>{operation.time}</td>
        <td>{valueMask(operation.value)}</td>
        <td>{cpfMask(operation.cpf.toString())}</td>
        <td>{operation.card}</td>
        <td>{operation.storeOwner}</td>
        <td>{operation.storeName}</td>
    </>
    );

  return (
    <div>
      <h2>{`Operations of ${title}`}</h2>
      <Table headers={headers} data={operations} renderRow={renderOperationRow} />
      <h2>{`Account Balance: ${valueMask(accountBalance)}`}</h2>
    </div>
  );
}