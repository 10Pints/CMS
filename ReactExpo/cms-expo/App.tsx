import { useState, useEffect, Platform } from 'react';
import { StyleSheet, Text, View, Platform as RNPlatform } from 'react-native'; // Renamed to avoid confusion
import axios from 'axios';
import { FlashList } from '@shopify/flash-list';

interface Customer {
  CustomerId: number;
  Name: string;
  address: string; // Updated to match server case
  status: string;  // Updated to match server case
}

export default function App() {
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchCustomers = async () => {
      try {
        console.log('Fetching customers from:', 'http://192.168.254.103:3000/api/customers');
        const response = await axios.get('http://192.168.254.103:3000/api/customers');
        console.log('Fetch response:', response.data);
        setCustomers(response.data || []);
        setError(null);
      } catch (error) {
        console.error('Error fetching customers:', error.message || error);
        setError('Failed to fetch data');
        setCustomers([]); // Default to empty array to avoid crash
      }
    };
    fetchCustomers();
  }, []);

  const renderItem = ({ item, index }: { item: Customer; index: number }) => (
    <View style={[styles.row, index % 2 === 0 ? styles.evenRow : styles.oddRow]}>
      <Text style={styles.cell}>{item.CustomerId}</Text>
      <Text style={styles.cell}>{item.Name}</Text>
      <Text style={styles.cell}>{item.address}</Text> {/* Added address */}
      <Text style={styles.cell}>{item.status}</Text>  {/* Added status */}
    </View>
  );

  const renderGrid = () => {
    if (error) return <Text style={styles.error}>{error}</Text>;
    if (RNPlatform.OS === 'web') {
      return customers.length > 0 ? (
        <View style={styles.webGrid}>
          {customers.map((item, index) => (
            <View key={item.CustomerId} style={[styles.row, index % 2 === 0 ? styles.evenRow : styles.oddRow]}>
              <Text style={styles.cell}>{item.CustomerId}</Text>
              <Text style={styles.cell}>{item.Name}</Text>
              <Text style={styles.cell}>{item.address}</Text> {/* Added address */}
              <Text style={styles.cell}>{item.status}</Text>  {/* Added status */}
            </View>
          ))}
        </View>
      ) : (
        <Text>Loading...</Text>
      );
    }
    return customers.length > 0 ? (
      <FlashList
        data={customers}
        numColumns={1}
        renderItem={renderItem}
        estimatedItemSize={100}
        ListHeaderComponent={() => (
          <View style={styles.header}>
            <Text style={styles.headerCell}>ID</Text>
            <Text style={styles.headerCell}>Name</Text>
            <Text style={styles.headerCell}>Address</Text> {/* Updated label */}
            <Text style={styles.headerCell}>Status</Text>  {/* Updated label */}
          </View>
        )}
      />
    ) : (
      <Text>Loading...</Text>
    );
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Refinery CMS Customers</Text>
      {renderGrid()}
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 10,
    backgroundColor: '#f0f0f0',
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 10,
    textAlign: 'center',
  },
  header: {
    flexDirection: 'row',
    backgroundColor: '#333',
    padding: 10,
  },
  headerCell: {
    flex: 1,
    color: '#fff',
    fontWeight: 'bold',
    textAlign: 'center',
  },
  row: {
    flexDirection: 'row',
    padding: 10,
  },
  evenRow: {
    backgroundColor: '#fff',
  },
  oddRow: {
    backgroundColor: '#f9f9f9',
  },
  cell: {
    flex: 1,
    textAlign: 'center',
  },
  webGrid: {
    flexDirection: 'column',
  },
  error: {
    color: 'red',
    textAlign: 'center',
  },
});
