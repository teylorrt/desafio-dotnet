export interface Operation {
    id: number;
    type: string;
    description: string;
    nature: string;
    sign: string;
    time: string;
    value: number;
    cpf: number;
    card: string;
    storeOwner: string;
    storeName: string;
}

export interface OperationGroupModel {
    name: string;
    accountBalance: number;
    operations: Operation[];
}