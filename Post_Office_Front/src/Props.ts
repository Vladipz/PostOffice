export interface ItemProps {
    name: string;
    weight: number;
  }
  
  export interface PersonProps {
    name: string;
    address: string;
    phoneNumber: string;
  }
  
  export interface PackageProps {
    id: string; // Assuming ObjectId is converted to string
    sender: PersonProps;
    receiver: PersonProps;
    distance: number;
    sentDate: Date; // Assuming DateTime is converted to string
    deliveryDate: Date; // Assuming DateTime is converted to string
    items: ItemProps[];
    deliveryCost: number;
    deliveryStatus: number; // Assuming Status is a valid TypeScript type
  }
  export interface PackageCardProps {
    packageItem: PackageProps;
    onClick: (item: ItemProps[])=> void
  }


  export interface CreatePackageProps {
    sender: PersonProps;
    receiver: PersonProps; 
    items: ItemProps[];
  }